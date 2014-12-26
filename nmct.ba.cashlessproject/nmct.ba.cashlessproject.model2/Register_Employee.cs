using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model
{
   public class Register_Employee
    {
        private Registers _RegisterID;

        public Registers RegisterID
        {
            get { return _RegisterID; }
            set { _RegisterID = value; }
        }

        private Employee _EmployeeID;

        public Employee EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        private string _From;

        public string From
        {
            get { return _From; }
            set { _From = value; }
        }

        private string _Until;

        public string Until
        {
            get { return _Until; }
            set { _Until = value; }
        }
    }
}
