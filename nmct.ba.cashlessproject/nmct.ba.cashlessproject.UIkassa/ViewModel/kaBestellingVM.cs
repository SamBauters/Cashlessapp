using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Input;
using be.belgium.eid;
using GalaSoft.MvvmLight.Command;
using nmct.ba.cashlessproject.model;
using Newtonsoft.Json;

namespace nmct.ba.cashlessproject.UIkassa.ViewModel
{
    class kaBestellingVM : ObservableObject, IPage
    {
        int registerID = 4;
        string mname = "BestellingVM";

        public string Name
        {
            get { return "Bestelling"; }
        }

        public kaBestellingVM(int MedewerkersID)
        {
            Van = DateTime.Now;

            GetProducts();
            GetRegisterById(registerID);
            GebruikersID = MedewerkersID;
        }

    

        private int _gebruikersID;
        public int GebruikersID
        {
            get { return _gebruikersID; }
            set {
                _gebruikersID = value;
                OnPropertyChanged("GebruikersID");
            }
        }

        private DateTime _van;
        public DateTime Van
        {
            get { return _van; }
            set {
                _van = value;
                OnPropertyChanged("Van");
            }
        }

        private DateTime _tot;

        public DateTime Tot
        {
            get { return _tot; }
            set {
                _tot = value;
                OnPropertyChanged("Tot");
            }
        }
        
        
        
        private ObservableCollection<Products> _products;
        public ObservableCollection<Products> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged("Products");
            }
        }

        private Products _selectedProduct;
        public Products SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
                Aantal = 1;
            }
        }

        private int _aantal;
        public int Aantal
        {
            get { return _aantal; }
            set {
                _aantal = value;
                OnPropertyChanged("Aantal");
            }
        }

        private ObservableCollection<Sales> _sales;
        public ObservableCollection<Sales> Sales
        {
            get
            {
                if (_sales == null)
                    _sales = new ObservableCollection<Sales>();
                return _sales;
            }
            set
            {
                _sales = value;
                OnPropertyChanged("Sales");
            }
        }

        private Registers _register;
        public Registers Register
        {
            get
            {
                if (_register == null)
                    _register = new Registers();
                return _register;
            }
            set {
                _register = value;
                OnPropertyChanged("Register");
            }
        }

        private Sales _selectedSale;
        public Sales SelectedSale
        {
            get { return _selectedSale; }
            set
            {
                _selectedSale = value;
                OnPropertyChanged("SelectedSale");
            }
        }
        
        private double _totaal;
        public double Totaal
        {
            get { return _totaal; }
            set {
                _totaal = value;
                OnPropertyChanged("Totaal");
            }
        }

        private Customers _klant;
        public Customers Klant
        {
            get {
                return _klant;
            }
            set
            {
                _klant = value;
                OnPropertyChanged("Klant");
            }
        }

        private ObservableCollection<Customers> _customers;
        public ObservableCollection<Customers> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                OnPropertyChanged("Customers");
            }
        }
        
        private async void GetProducts()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:1092/api/Product");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Products = JsonConvert.DeserializeObject<ObservableCollection<Products>>(json);
                }
                else
                {
                    MakeErrorLog("Producten konden niet worden opgehaald uit DB.", mname, "GetProducts");
                }
            }
        }

        public ICommand VerhoogAantalCommand
        {
            get { return new RelayCommand(VerhoogAantal); }
        }

        private void VerhoogAantal()
        {
            Aantal++;
        }

        public ICommand VerminderAantalCommand
        {
            get { return new RelayCommand(VerminderAantal); }
        }

        private void VerminderAantal()
        {
            if(Aantal > 1)
                Aantal--;
        }

        public ICommand VoegToeAanBestellingCommand
        {
            get { return new RelayCommand(VoegToeAanBestelling); }
        }

        private void VoegToeAanBestelling()
        {
            Sales s = new Sales();
            if(SelectedProduct != null && Aantal != 0 && Klant != null)
            {
                s.CustomerID = Klant.ID;
                s.RegisterID = registerID;
                s.RegisterName = Register.RegisterName;
                s.ProductID = SelectedProduct.ID;
                s.ProductName = SelectedProduct.ProductName;
                s.Amount = Aantal;
                s.Price = SelectedProduct.Price;
                s.TotalPrice = Aantal * SelectedProduct.Price;

                Sales.Add(s);
                BerekenTotaal();
                ControleerPrijs();

                Aantal = 1;
                SelectedProduct = null;
            }
        }

        private async void GetRegisterById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:1092/api/Kassa/" + id);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Register = JsonConvert.DeserializeObject<Registers>(json);
                }
                else
                    MakeErrorLog("Kassa kon niet worden opgevraagd aan de hand van RegisterID", mname, "GetRegisterByID");
            }
        } 

        void BerekenTotaal()
        {
            Totaal = 0;

            foreach (Sales s in Sales)
                Totaal += s.TotalPrice;
        }

        public ICommand VerwijderUitLijstCommand
        {
            get { return new RelayCommand(VerwijderUitLijst); }
        }

        private void VerwijderUitLijst()
        {
            if (SelectedSale != null)
                Sales.Remove(SelectedSale);
            else
                MakeErrorLog("Sale uit lijst proberen verwijderen zonder Sale te selecteren", mname, "VerwijderUitLijst");
                
            BerekenTotaal();
        }

        public ICommand InsertIntoDBCommand
        {
            get { return new RelayCommand(InsertIntoDB); }
        }

        private async void InsertIntoDB()
        {
            DateTime tijdstip = DateTime.Now;
            if (Sales != null)
            {
                if (Totaal < Klant.Balance)
                {
                    foreach (Sales s in Sales)
                    {
                        s.Timestamp = tijdstip;
                        using (HttpClient client = new HttpClient())
                        {
                            string sale = JsonConvert.SerializeObject(s);
                            HttpResponseMessage response = await
                                client.PostAsync("http://localhost:1092/api/Sale", new StringContent(sale,Encoding.UTF8, "application/json"));
                            if (response.IsSuccessStatusCode)
                            {
                            }
                            else
                            {
                                MakeErrorLog("Kon Sale niet toevoegen in DB", mname, "InsertIntoDB");
                            }
                        }
                    }
                    Sales = new ObservableCollection<Sales>();
                    UpdateCustomer();
                    LogOut();
                }
                else
                {
                    MakeErrorLog("Totaal bedrag van bestelling is groter dan saldo van klant.", mname, "InsertIntoDB");
                }
            }
            else
            {
                MakeErrorLog("Er kan geen lege bestelling toegevoegd worden.", mname, "InsertIntoDB");
            }
        }

        private async void UpdateCustomer()
        {
            Customers c = Klant;
            c.Balance -= Totaal;

            using (HttpClient client = new HttpClient())
            {
                string customer = JsonConvert.SerializeObject(c);
                HttpResponseMessage response = await
                client.PutAsync("http://localhost:1092/api/Klant", new StringContent(customer, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    Totaal = 0;
                    GetCustomer();
                }
                else
                    MakeErrorLog("Kon klant niet updaten", mname, "UpdateCustomer");
            }
        }

        public ICommand LoadEidCommand
        {
            get { return new RelayCommand(LoadEid); }
        }

        private void LoadEid()
        {
            BEID_ReaderSet.initSDK();

            try
            {
                BEID_ReaderSet readerSet = BEID_ReaderSet.instance();
                BEID_ReaderContext reader = readerSet.getReader();

                if (reader.isCardPresent())
                {
                    if (reader.getCardType() == BEID_CardType.BEID_CARDTYPE_EID)
                    {
                        BEID_EIDCard card = reader.getEIDCard();
                        BEID_EId doc = card.getID();

                        Klant = new Customers();
                        Klant.CustomerName = doc.getFirstName1() + " " + doc.getSurname();

                        GetCustomer();
                    }
                    else
                    {
                        MakeErrorLog("Deze versie van de E-ID wordt niet ondersteund", mname, "LoadEid");
                    }
                }
                else
                {
                    MakeErrorLog("Er is geen E-ID aanwezig", mname, "LoadEid");
                }

                BEID_ReaderSet.releaseSDK();
            }
            catch (Exception)
            {
                MakeErrorLog("Er liep iets fout bij het inlezen van de E-id", mname, "LoadEid");
            }
        }

        private async void GetCustomer()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:1092/api/Klant");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Customers = JsonConvert.DeserializeObject<ObservableCollection<Customers>>(json);

                    Customers inDB = null;
                    foreach (Customers c in Customers)
                    {
                        if (c.CustomerName == Klant.CustomerName)
                            inDB = c;
                    }

                    if (inDB != null)
                    {
                        Klant = inDB;
                    }
                    else
                    {
                        MakeErrorLog("Klant moet zich nog registreren", mname, "GetCustomer");
                    }
                }
                else
                {
                    MakeErrorLog("Er liep iets fout bij het ophalen van de klant uit de DB", mname, "GetCustomer");
                }
            }
        }

        private void ControleerPrijs()
        {
            if (Klant != null)
            {
                double overschrijding = Totaal - Klant.Balance;
                overschrijding = Math.Round(overschrijding, 2);

                if (Totaal > Klant.Balance)
                {
                    MessageBox.Show("Overschrijding van het saldo met € " + overschrijding + ". Gelieve iets te verwijderen uit de bestelling.", " " ,MessageBoxButton.OK, MessageBoxImage.Warning);
                    MakeErrorLog("Klant " + Klant.CustomerName + " overschreed zijn/haar huidig saldo met € " + overschrijding, mname, "ControleerPrijs");
                }
            }
            else
                MakeErrorLog("Geen E-ID aanwezig.", mname, "ControleerPrijs");
        }

        private void LogOut()
        {
            Tot = DateTime.Now;

            Register_Employee re = new Register_Employee();
            //re.Register = registerID;
            //re.Employee = GebruikersID;
            re.From = DateTimeToUnixTimeStamp(Van);
            re.Until = DateTimeToUnixTimeStamp(Tot);

            InsertRegisterEmployeeIntoDB(re);
        }

        private async void InsertRegisterEmployeeIntoDB(Register_Employee re)
        {
            using (HttpClient client = new HttpClient())
            {
                string registeremployee = JsonConvert.SerializeObject(re);
                HttpResponseMessage response = await
                    client.PostAsync("http://localhost:1092/api/RegisterEmployee", new StringContent(registeremployee, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
                    appvm.ChangePage(new kaInlogVM());
                }
                else
                {
                    MakeErrorLog("Kon Register_Employee niet toevoegen in DB", mname, "InsertRegisterEmployeeIntoDB");
                }
            }
        }

        private void MakeErrorLog(string message, string classStackTrace, string methodStackTrace)
        {
            Errorlog errorLog = new Errorlog();
            errorLog.RegisterID = registerID;
            errorLog.TimeStamp = DateTimeToUnixTimeStamp(DateTime.Now);
            errorLog.Message = message;
            errorLog.StackTrace = "Class: " + classStackTrace + " Method: " + methodStackTrace;

            AddErrorlog(errorLog);
        }

        public async void AddErrorlog(Errorlog e)
        {
            using (HttpClient client = new HttpClient())
            {
                string errorlog = JsonConvert.SerializeObject(e);
                HttpResponseMessage response = await
                    client.PostAsync("http://localhost:1092/api/Errorlog", new StringContent(errorlog,
                        Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Error added.");
                }
            }
        }

        private static int DateTimeToUnixTimeStamp(DateTime t)
        {
            var date = new DateTime(1970, 1, 1, 0, 0, 0, t.Kind);
            var unixTimestamp = Convert.ToInt32((t - date).TotalSeconds);

            return unixTimestamp;
        }
    }
}

