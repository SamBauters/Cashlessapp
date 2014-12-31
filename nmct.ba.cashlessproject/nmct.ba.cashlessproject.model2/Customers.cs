using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace nmct.ba.cashlessproject.model
{
   public class Customers : IDataErrorInfo
   {
       #region props
       private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _CustomerName;
        [Required(ErrorMessage = "Naam is verplicht")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "De naam moet tussen de 3 en 50 karakters bevatten.")]

        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }

        private string _Address;

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        private byte[] _Picture;

        public byte[] Picture
        {
            get { return _Picture; }
            set { _Picture = value; }
        }

        private double _Balance;

        public double Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
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
