using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model
{
    public class Sales
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _Timestamp;

        public string Timestamp
        {
            get { return _Timestamp; }
            set { _Timestamp = value; }
        }

        private Customers _CustomerID;

        public Customers CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }

        private Registers _RegisterID;

        public Registers RegisterID
        {
            get { return _RegisterID; }
            set { _RegisterID = value; }
        }

        private Products _ProductID;

        public Products ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }

        private int _Amount;

        public int Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        private double _TotalPrice;

        public double TotalPrice
        {
            get { return _TotalPrice; }
            set { _TotalPrice = value; }
        }
    }
}
