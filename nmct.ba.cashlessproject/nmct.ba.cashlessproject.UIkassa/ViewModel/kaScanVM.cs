using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace nmct.ba.cashlessproject.UIkassa.ViewModel
{
    class kaScanVM : ObservableObject, IPage
    {
        public string Name
        {
            get { return "Scan"; }
        }

        public ICommand BestellingCommand
        {
            get { return new RelayCommand(Bestelling); }
        }

        private void Bestelling()
        {
            ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
            appvm.ChangePage(new kaBestellingVM());
        }
        public ICommand AfmeldenCommand
        {
            get { return new RelayCommand(Afmelden); }
        }

        private void Afmelden()
        {
            ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
            appvm.ChangePage(new kaInlogVM());
        }
    }
}
