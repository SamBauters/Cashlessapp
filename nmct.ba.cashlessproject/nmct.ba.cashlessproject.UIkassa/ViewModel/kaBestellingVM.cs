using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using nmct.ba.cashlessproject.model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Net.Http;
using Newtonsoft.Json;

namespace nmct.ba.cashlessproject.UIkassa.ViewModel
{
    class kaBestellingVM : ObservableObject, IPage
    {
    public string Name
        {
            get { return "Bestelling"; }
        }
        public kaBestellingVM()
        {
            GetProducten();
        }

        private ObservableCollection<Products> _products;

        public ObservableCollection<Products> Products
        {
            get { return _products; }
            set { _products = value; OnPropertyChanged("Products"); }
        }

        private async void GetProducten()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:1092/api/Product");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Products = JsonConvert.DeserializeObject<ObservableCollection<Products>>(json);
                }
            }
        }

        private Products _selectedProduct;
        public Products SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; OnPropertyChanged("SelectedProduct"); }
        }

        private string _error;
        public string Error
        {
            get { return _error; }
            set { _error = value; OnPropertyChanged("Error"); }
        }

        public ICommand TerugCommand
        {
            get { return new RelayCommand(Terug); }
        }

        private void Terug()
        {
            ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
            appvm.ChangePage(new kaScanVM());
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

       /* public ICommand AddProductCommand
        {
            get { return new RelayCommand(AddProduct); }
        }*/

        private List<Sales> _bestellingen;

        public List<Sales> Bestellingen
        {
            get { return _bestellingen; }
            set { _bestellingen = value; OnPropertyChanged("Bestelling"); }
        }
    }
}

