using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model
{
    public class Registers
    {
        private Register_Employee _ID;

        public Register_Employee ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _RegisterName;

        public string RegisterName
        {
            get { return _RegisterName; }
            set { _RegisterName = value; }
        }

        private string _Device;

        public string Device
        {
            get { return _Device; }
            set { _Device = value; }
        }
    }
}
