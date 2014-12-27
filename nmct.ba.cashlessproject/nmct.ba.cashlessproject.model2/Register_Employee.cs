using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model
{
   public class Register_Employee
    {
        private Registers _Register;

        public Registers Register
        {
            get { return _Register; }
            set { _Register = value; }
        }

        private Employee _Employee;

        public Employee Employee
        {
            get { return _Employee; }
            set { _Employee = value; }
        }

        private int _From;

        public int From
        {
            get { return _From; }
            set { _From = value; }
        }

        private int _Until;

        public int Until
        {
            get { return _Until; }
            set { _Until = value; }
        }

       public Register_Employee()
       {

       }
    }
}
