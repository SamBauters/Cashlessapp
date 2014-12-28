using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model
{
    public class Errorlog : IDataErrorInfo
    {
        private int _RegisterID;

        public int RegisterID
        {
            get { return _RegisterID; }
            set { _RegisterID = value; }
        }

        private int _TimeStamp;

        public int TimeStamp
        {
            get { return _TimeStamp; }
            set { _TimeStamp = value; }
        }

        private string _message;
        [Required(ErrorMessage = "Message is verplicht")]
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        private string _StackTrace;

        public string StackTrace
        {
            get { return _StackTrace; }
            set { _StackTrace = value; }
        }

        public bool IsValid()
        {
            return Validator.TryValidateObject(this, new ValidationContext(this, null, null), null, true);
        }

        public string this[string columnName]
        {
            get
            {
                try
                {
                    object value = this.GetType().GetProperty(columnName).GetValue(this);
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = columnName });
                }
                catch (ValidationException ex)
                {
                    return ex.Message;
                }
                return String.Empty;
            }
        }

        public string Error
        {
            get { return null; }
        }
    }
}
