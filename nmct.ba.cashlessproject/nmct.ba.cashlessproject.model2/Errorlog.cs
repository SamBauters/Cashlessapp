using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model
{
    class Errorlog
    {
        private Registers _RegisterID;

        public Registers RegisterID
        {
            get { return _RegisterID; }
            set { _RegisterID = value; }
        }

        private DateTime _Timestamp;

        public DateTime Timestamp
        {
            get { return _Timestamp; }
            set { _Timestamp = value; }
        }

        private string _Stacktrace;

        public string Stacktrace
        {
            get { return _Stacktrace; }
            set { _Stacktrace = value; }
        }
    }
}
