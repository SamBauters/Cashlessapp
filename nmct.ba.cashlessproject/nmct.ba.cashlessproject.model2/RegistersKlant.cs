using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model
{
    public class RegistersKlant
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _registerName;

        public string RegisterName
        {
            get { return _registerName; }
            set { _registerName = value; }
        }
        private string _device;

        public string Device
        {
            get { return _device; }
            set { _device = value; }
        }

        private int _employeeId;

        public int EmployeeID
        {
            get { return _employeeId; }
            set { _employeeId = value; }
        }


        private string _employeeName;

        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        private Double _from;

        public Double From
        {
            get { return _from; }
            set { _from = value; }
        }

        private Double _until;

        public Double Until
        {
            get { return _until; }
            set { _until = value; }
        }

    }
}

