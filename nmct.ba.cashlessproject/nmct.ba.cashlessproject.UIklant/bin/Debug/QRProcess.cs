using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using com.google.zxing.qrcode;
using com.google.zxing;
using com.google.zxing.common;
using System.Threading;

namespace QRWindowsClient
{
    /// <summary>
    /// Class to decode qr bitmaps in a separated thread.
    /// </summary>
    class QRProcess
    {
        public QRCodeReader reader = new QRCodeReader();
        public Bitmap CurrentBitmap { get; private set; }
        public event EventHandler<ProcessArgs> ResultFound;

        public bool Run { get; set; }
        public bool newBitmap { get; set; }

        /// <summary>
        /// When a new bitmap is available, call this method to prepare the bitmap for be consumed.
        /// </summary>
        /// <param name="newBitmap">The bitmap to be consumed.</param>
        public void NewBitmap(Bitmap newBitmap)
        {
            Monitor.Enter(this);
            if (this.newBitmap == false)
            {
                this.CurrentBitmap = (Bitmap)newBitmap.Clone();
                this.newBitmap = true;
                Monitor.PulseAll(this);
            }
            Monitor.Exit(this);
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            Monitor.Enter(this);
            this.Run = false;
            Monitor.PulseAll(this);
            Monitor.Exit(this);
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            this.Run = true;

            ThreadStart start = new ThreadStart(delegate
            {
                while (this.Run)
                {
                    Monitor.Enter(this);
                    while (this.newBitmap == false)
                    {
                        Monitor.Wait(this, 1000);
                    }
                    using (Bitmap bitmap = (Bitmap)this.CurrentBitmap.Clone())
                    {
                        Monitor.Exit(this);
                        var result = this.Process(bitmap);
                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            if (this.ResultFound != null)
                            {
                                ProcessArgs args = new ProcessArgs() { Result = result };
                                this.ResultFound(this, args);
                                this.Run = false;
                            }
                        }
                    }

                    // the class is ready to accept a new bitmap to evaluate.
                    this.newBitmap = false;
                }
            });

            Thread t = new Thread(start);
            t.Start();
        }



        /// <summary>
        /// Processes the specified bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <returns>The message decoded or string.empty</returns>
        public string Process(Bitmap bitmap)
        {
            try
            {
                com.google.zxing.LuminanceSource source = new RGBLuminanceSource(bitmap, bitmap.Width, bitmap.Height);
                var binarizer = new HybridBinarizer(source);
                var binBitmap = new BinaryBitmap(binarizer);
                return reader.decode(binBitmap).Text;
            }
            catch
            {
                return string.Empty;
            }
        }
    }

    /// <summary>
    /// Class to pass arguments between QRProcess events.
    /// </summary>
    public class ProcessArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public string Result { get; set; }
    }
}
