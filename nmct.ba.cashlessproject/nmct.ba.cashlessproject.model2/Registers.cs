using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace nmct.ba.cashlessproject.model
{
    public class Registers : IDataErrorInfo
    {
        #region props
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _RegisterName;
        [Required(ErrorMessage = "Kassanaam is verplicht.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$", ErrorMessage = "Er zijn geen speciale tekens toegelaten")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Kassanaam moet tussen de 3 en 30 karakters lang zijn.")]

        public string RegisterName
        {
            get { return _RegisterName; }
            set { _RegisterName = value; }
        }

        private string _Device;
        [Required(ErrorMessage = "Toestel is verplicht.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Toestel moet tussen de 2 en 30 karakters lang zijn.")]

        public string Device
        {
            get { return _Device; }
            set { _Device = value; }
        }

                public Registers()
        {

        }

        public override string ToString()
        {
            return RegisterName + " (" + Device + ")";
        }
        #endregion
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
