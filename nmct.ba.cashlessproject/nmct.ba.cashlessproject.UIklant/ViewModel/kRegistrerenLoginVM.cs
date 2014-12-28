using be.belgium.eid;
using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
using nmct.ba.cashlessproject.model;
using nmct.ba.cashlessproject.UIklant.Converter;
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
    class kRegistrerenLoginVM : ObservableObject, IPage
    {
        string mname = "kRegistrerenLoginVM";
        public kRegistrerenLoginVM()
        {
        }
        public string Name
        {
            get { return "Registreren met login"; }
        }

        private Customers _klant = new Customers();
        public Customers Klant
        {
            get { return _klant; }
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

        private string _voornaam;
        public string Voornaam
        {
            get { return _voornaam; }
            set
            {
                _voornaam = value;
                OnPropertyChanged("Voornaam");
            }
        }

        private string _naam;
        public string Naam
        {
            get { return _naam; }
            set
            {
                _naam = value;
                OnPropertyChanged("Naam");
            }
        }

        private string _adres;
        public string Adres
        {
            get { return _adres; }
            set
            {
                _adres = value;
                OnPropertyChanged("Adres");
            }
        }

        private string _stad;
        public string Stad
        {
            get { return _stad; }
            set
            {
                _stad = value;
                OnPropertyChanged("Stad");
            }
        }

        private Boolean _registered = false;
        public Boolean Registered
        {
            get { return _registered; }
            set
            {
                _registered = value;
                OnPropertyChanged("Registered");
            }
        }

        //lees info van E-ID
        public ICommand LoadEidCommand
        {
            get { return new RelayCommand(LoadEid); }
        }

        private void LoadEid()
        {
            BEID_ReaderSet.initSDK();
            Registered = false;

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
                        BEID_Picture picture = card.getPicture();
                        byte[] pictureBytes = picture.getData().GetBytes();

                        Klant.CustomerName = doc.getFirstName1() + " " + doc.getSurname();
                        Klant.Address = doc.getStreet() + ", " + doc.getZipCode() + " " + doc.getMunicipality();
                        Klant.Picture = pictureBytes;
                        Klant.Balance = 0;

                        Voornaam = doc.getFirstName1();
                        Naam = doc.getSurname();
                        Adres = doc.getStreet();
                        Stad = doc.getZipCode() + " " + doc.getMunicipality();

                        CheckIfCustomerExists();
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

        //kijk of klant al bestaat
        private async void CheckIfCustomerExists()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:1092/api/Klant");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Customers = JsonConvert.DeserializeObject<ObservableCollection<Customers>>(json);
                }
                else
                {
                    MakeErrorLog("Er liep iets fout met het ophalen van de klanten.", mname, "CheckIfCustomerExists");
                }

                Customers inDB = null;
                foreach (Customers c in Customers)
                {
                    if (c.CustomerName == Klant.CustomerName)
                        inDB = c;
                }

                if (inDB != null)
                {
                    Klant = inDB;
                    Registered = true;
                }
                else
                {
                    AddCustomer();
                }
            }
        }

        //customer toevoegen
        private async void AddCustomer()
        {
            using (HttpClient client = new HttpClient())
            {
                string klant = JsonConvert.SerializeObject(Klant);
                HttpResponseMessage response = await
                    client.PostAsync("http://localhost:1092/api/Klant", new StringContent(klant,
                        Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    Registered = true;
                }
                else
                {
                    MakeErrorLog("Er liep iets mis met het toevoegen van de klant.", mname, "AddCustomer");
                }
            }
        }

        //inloggen
        public ICommand LogInCommand
        {
            get { return new RelayCommand(LogIn); }
        }

        private void LogIn()
        {
            ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;

            if (Registered == true)
            {
                kOpladenVM opladen = new kOpladenVM();
                opladen.Klant = Klant;
                appvm.ChangePage(opladen);
            }
            else
            {
                MakeErrorLog("Poging tot inloggen zonder kaart te lezen.", mname, "LogIn");
            }
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
