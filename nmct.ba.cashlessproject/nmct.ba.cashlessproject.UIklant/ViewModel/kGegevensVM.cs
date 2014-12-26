using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.UIklant.ViewModel
{
    class kGegevensVM : ObservableObject, IPage
    {
        public string Name
        {
            get { return "Mijn gegevens bewerken"; }
        }
        private string _gegevens;

        public string Gegevens
        {
            get { return _gegevens; }
            set { _gegevens = value; OnPropertyChanged("Gegevens"); }

        }
    }
}
