using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace nmct.ba.cashlessproject.model
{
    public class Products : IDataErrorInfo
    {
        #region prop
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _ProductName;
        [Required(ErrorMessage = "Productnaam is verplicht.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Productnaam moet tussen de 3 en 50 karakters lang zijn.")]

        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }

        private double _Price;
        [Required(ErrorMessage = "Prijs is verplicht")]
        public double Price
        {
            get { return _Price; }
            set { _Price = value; }
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
