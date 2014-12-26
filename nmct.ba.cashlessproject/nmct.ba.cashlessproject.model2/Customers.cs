using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace nmct.ba.cashlessproject.model
{
   public class Customers
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _CustomerName;

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

        private string _sex;

        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        private DateTime _birthDate;

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }
    }
}
