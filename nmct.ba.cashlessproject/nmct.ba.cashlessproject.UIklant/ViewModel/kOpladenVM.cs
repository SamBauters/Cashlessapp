using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using nmct.ba.cashlessproject.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace nmct.ba.cashlessproject.UIklant.ViewModel
{
    class kOpladenVM : ObservableObject, IPage
    {
        string mname = "OpladenVM";

        public string Name
        {
            get { return "Opladen"; }
        }
        public kOpladenVM(Customers customers)
        {
            Klant = customers;
        }

        public kOpladenVM()
        {
            
        }

        private string _klantName;
        public string KlantName
        {
            get { return _klantName; }
            set {
                _klantName = value;
                OnPropertyChanged("KlantName");
            }
        }
        
        private Customers _klant;
        public Customers Klant
        {
            get { return _klant; }
            set
            {
                _klant = value;
                OnPropertyChanged("Klant");
                NieuwSaldo = Klant.Balance;
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

        private double _nieuwSaldo;
        public double NieuwSaldo
        {
            get { return _nieuwSaldo; }
            set
            {
                _nieuwSaldo = value;
                OnPropertyChanged("NieuwSaldo");
            }
        }

        private double _bedrag;
        public double Bedrag
        {
            get { return _bedrag; }
            set
            {
                _bedrag = value;
                OnPropertyChanged("Bedrag");
            }
        }

        private Boolean _updated = false;

        public Boolean Updated
        {
            get { return _updated; }
            set
            {
                _updated = value;
                OnPropertyChanged("Updated");
            }
        }

        //5euro
        public ICommand Add5EuroCommand
        {
            get { return new RelayCommand(Add5Euro); }
        }

        private void Add5Euro()
        {
            if ((Bedrag + 5) <= 100)
            {
                Bedrag += 5;
                NieuwSaldo += 5;
            }               
        }

        //10euro
        public ICommand Add10EuroCommand
        {
            get { return new RelayCommand(Add10Euro); }
        }

        private void Add10Euro()
        {
            if ((Bedrag + 10) <= 100)
            {
                Bedrag += 10;
                NieuwSaldo += 10;
            }
        }

        //20euro
        public ICommand Add20EuroCommand
        {
            get { return new RelayCommand(Add20Euro); }
        }

        private void Add20Euro()
        {
            if ((Bedrag + 20) <= 100)
            {
                Bedrag += 20;
                NieuwSaldo += 20;
            }
        }

        //50euro
        public ICommand Add50EuroCommand
        {
            get { return new RelayCommand(Add50Euro); }
        }

        private void Add50Euro()
        {
            if ((Bedrag + 50) <= 100)
            {
                Bedrag += 50;
                NieuwSaldo += 50;
            }
        }

        //Annuleer
        public ICommand AnnuleerCommand
        {
            get { return new RelayCommand(Annuleer); }
        }

        private void Annuleer()
        {
            Bedrag = 0;
            NieuwSaldo = Klant.Balance;
        }

        //update customer
        public ICommand UpdateCustomerCommand
        {
            get { return new RelayCommand(UpdateCustomer); }
        }

        public async void UpdateCustomer()
        {
            if (Updated == false)
            {
                Klant.Balance = Convert.ToDouble(NieuwSaldo);

                using (HttpClient client = new HttpClient())
                {
                    string customer = JsonConvert.SerializeObject(Klant);
                    HttpResponseMessage response = await
                    client.PutAsync("http://localhost:1092/api/Klant", new StringContent(customer,
                    Encoding.UTF8, "application/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        Bedrag = 0;
                        Updated = true;
                        MessageBox.Show("Bedankt voor je herlaadbeurt!");
                        GetCustomer();
                        Updated = false;
                    }
                    else
                    {
                        MakeErrorLog("Er liep iets fout met het updaten van het saldo van de klant", mname, "UpdateCustomer");
                    }
                }
            }
            else
            {
                MakeErrorLog("Klant" + Klant.CustomerName + "heeft geprobeerd om voor de 2de maal geld op te laden.", mname, "UpdateCustomer");
            }          
        }

        //Klanten ophalen
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

        //afmelden
        public ICommand AfmeldenCommand
        {
            get { return new RelayCommand(Afmelden); }
        }

        private void Afmelden()
        {
            ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
            appvm.ChangePage(new kRegistrerenLoginVM());
        }

        //Errorlog aanmaken
        private void MakeErrorLog(string message, string classStackTrace, string methodStackTrace)
        {
            Errorlog errorLog = new Errorlog();
            errorLog.RegisterID = 0;
            errorLog.TimeStamp = DateTimeToUnixTimeStamp(DateTime.Now);
            errorLog.Message = message;
            errorLog.StackTrace = "Class: " + classStackTrace + " Method: " + methodStackTrace;

            AddErrorlog(errorLog);
        }

        //Errorlog wegschrijven naar DB
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

        //DateTime convert to UnixTimeStamp
        private static int DateTimeToUnixTimeStamp(DateTime t)
        {
            var date = new DateTime(1970, 1, 1, 0, 0, 0, t.Kind);
            var unixTimestamp = System.Convert.ToInt32((t - date).TotalSeconds);

            return unixTimestamp;
        }
    }
}
