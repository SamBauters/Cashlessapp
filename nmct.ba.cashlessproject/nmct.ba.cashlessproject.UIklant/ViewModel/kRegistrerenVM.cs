using be.belgium.eid;
using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
using nmct.ba.cashlessproject.model;
using nmct.ba.cashlessproject.UIklant.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace nmct.ba.cashlessproject.UIklant.ViewModel
{
    class kRegistrerenVM : ObservableObject, IPage
    {
        public kRegistrerenVM()
        {
        }
        public string Name
        {
            get { return "Registreren"; }
        }

        public ICommand OpladenCommand
        {
            get { return new RelayCommand(Opladen); }
        }

        private void Opladen()
        {
            ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
            appvm.ChangePage(new kOpladenVM());
        }
        public ICommand AnnulerenCommand
        {
            get { return new RelayCommand(Annuleren); }
        }

        private void Annuleren()
        {
            ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
            appvm.ChangePage(new kStartVM());
        }
        public ICommand LeesKaartCommand
        {
            get { return new RelayCommand(Reader); }
        }
        public void Reader()
        {
            BEID_ReaderSet.initSDK();
            // access the eID card here
            if (BEID_ReaderSet.instance().readerCount() > 0)
            {
                BEID_ReaderContext readerContext = readerContext = BEID_ReaderSet.instance().getReader();
                if (readerContext != null)
                {
                    if (readerContext.getCardType() == BEID_CardType.BEID_CARDTYPE_EID)
                    {
                        Customers c = new Customers();
                        BEID_EIDCard card = readerContext.getEIDCard();
                        BEID_Picture picture;
                        picture = card.getPicture();
                        byte[] bytearray;
                        bytearray = picture.getData().GetBytes();
                        c.Picture = bytearray;
                        //
                        c.Address = card.getID().getStreet() + " " + card.getID().getZipCode();
                        c.CustomerName = card.getID().getFirstName() + " " + card.getID().getSurname();
                        SelectedCustomer = c;
                        OnPropertyChanged("SelectedCustomer");
                    }
                }
            }
            BEID_ReaderSet.releaseSDK();
        }

        public void ClickSave()
        {
            AddCustomer();
        }

        public ICommand ClickSaveCommand
        {
            get { return new RelayCommand(ClickSave); }
        }

        private Customers _selectedCustomer;
        public Customers SelectedCustomer
        {
            get { return _selectedCustomer; }
            set { _selectedCustomer = value; OnPropertyChanged("SelectedCustomer"); }
        }

        public async void AddCustomer()
        {
            Customers newCustomer = _selectedCustomer;
            using (HttpClient client = new HttpClient())
            {
                string emp = JsonConvert.SerializeObject(newCustomer);
                HttpResponseMessage response = await client.PostAsync("http://localhost:1092/api/Klant", new StringContent(emp, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Gelukt", "Information ... ");
                }
            }
        }
    }
}
