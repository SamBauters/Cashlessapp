using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace nmct.ba.cashlessproject.model
{
    public class Employee : IDataErrorInfo
    {

        #region props
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _EmployeeName;
        [Required(ErrorMessage = "Naam is verplicht")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$", ErrorMessage = "Er zijn geen speciale tekens toegelaten")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "De naam moet tussen de 3 en 50 karakters bevatten.")]
        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }

        private string _EmployeeLastname;
        [Required(ErrorMessage = "Naam is verplicht")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$", ErrorMessage = "Er zijn geen speciale tekens toegelaten")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "De naam moet tussen de 3 en 50 karakters bevatten.")]

        public string EmployeeLastname
        {
            get { return _EmployeeLastname; }
            set { _EmployeeLastname = value; }
        }

        private string _Address;
        [Required(ErrorMessage = "Het adres is verplicht")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$", ErrorMessage = "Er zijn geen speciale tekens toegelaten")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Het adres moet tussen de 3 en 50 karakters bevatten.")]
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        private string _Email;
        [Required(ErrorMessage = "Emailadres is verplicht")]
        [EmailAddress(ErrorMessage = "Het emailadres is niet correct")]

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _Phone;
        [Required(ErrorMessage = "Telefoonnummer is verplicht")]
        [StringLength(20, MinimumLength = 9, ErrorMessage = "Telefoonnummer moet tussen de 9 en 20 karakters bevatten")]
        [RegularExpression(@"^[0-9''-'\s\(\)\-\+]*$", ErrorMessage = "Geen geldig telefoonnummer")]

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
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
