using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using nmct.ba.cashlessproject.model;
using Newtonsoft.Json;

namespace nmct.ba.cashlessproject.UIkassa.ViewModel
{
    class kaInlogVM : ObservableObject, IPage
    {
        int registerID = 4;
        string mname = "AanmeldenVM";

        public string Name
        {
            get { return "Aanmelden"; }
        }

        public kaInlogVM()
        {
            GetEmployees();
        }

        private string _gebruikersID;
        public string GebruikersID
        {
            get { return _gebruikersID; }
            set {
                _gebruikersID = value;
                OnPropertyChanged("GebruikersID");
            }
        }

        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                OnPropertyChanged("Employees");
            }
        }

        private Boolean _isID;

        public Boolean IsID
        {
            get { return _isID; }
            set
            {
                _isID = value;
                OnPropertyChanged("IsID");
            }
        }
        

        #region "Knoppen"
        //0
        public ICommand Voeg0ToeCommand
        {
            get { return new RelayCommand(Voeg0Toe); }
        }
        private void Voeg0Toe()
        {
            GebruikersID = GebruikersID + "0";
        }

        //1
        public ICommand Voeg1ToeCommand
        {
            get { return new RelayCommand(Voeg1Toe); }
        }
        private void Voeg1Toe()
        {
            GebruikersID = GebruikersID + "1";
        }

        //2
        public ICommand Voeg2ToeCommand
        {
            get { return new RelayCommand(Voeg2Toe); }
        }
        private void Voeg2Toe()
        {
            GebruikersID = GebruikersID + "2";
        }

        //3
        public ICommand Voeg3ToeCommand
        {
            get { return new RelayCommand(Voeg3Toe); }
        }
        private void Voeg3Toe()
        {
            GebruikersID = GebruikersID + "3";
        }

        //4
        public ICommand Voeg4ToeCommand
        {
            get { return new RelayCommand(Voeg4Toe); }
        }
        private void Voeg4Toe()
        {
            GebruikersID = GebruikersID + "4";
        }

        //5
        public ICommand Voeg5ToeCommand
        {
            get { return new RelayCommand(Voeg5Toe); }
        }
        private void Voeg5Toe()
        {
            GebruikersID = GebruikersID + "5";
        }

        //6
        public ICommand Voeg6ToeCommand
        {
            get { return new RelayCommand(Voeg6Toe); }
        }
        private void Voeg6Toe()
        {
            GebruikersID = GebruikersID + "6";
        }

        //7
        public ICommand Voeg7ToeCommand
        {
            get { return new RelayCommand(Voeg7Toe); }
        }
        private void Voeg7Toe()
        {
            GebruikersID = GebruikersID + "7";
        }

        //8
        public ICommand Voeg8ToeCommand
        {
            get { return new RelayCommand(Voeg8Toe); }
        }
        private void Voeg8Toe()
        {
            GebruikersID = GebruikersID + "8";
        }

        //9
        public ICommand Voeg9ToeCommand
        {
            get { return new RelayCommand(Voeg9Toe); }
        }
        private void Voeg9Toe()
        {
            GebruikersID = GebruikersID + "9";
        }

        //wissen
        public ICommand WissenCommand
        {
            get { return new RelayCommand(Wissen); }
        }
        private void Wissen()
        {
            GebruikersID = "";
        }
        #endregion

        private async void GetEmployees()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:1092/api/Medewerker");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Employees = JsonConvert.DeserializeObject<ObservableCollection<Employee>>(json);
                }
                else
                    MakeErrorLog("Er liep iets fout bij het ophalen van de werknemers.", mname, "GetEmployees");
            }
        }

        public ICommand AanmeldenCommand
        {
            get { return new RelayCommand(Aanmelden); }
        }
        private void Aanmelden()
        {
            CheckGebruikersID();

            if (IsID == true)
            {
                ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
                //kaBestellingVM bestelling = new kaBestellingVM();
                //bestelling.GebruikersID = Convert.ToInt32(GebruikersID);
                appvm.ChangePage(new kaBestellingVM(Convert.ToInt32(GebruikersID)));
                //appvm.ChangePage(bestelling);
            }
            else
            {
                MessageBox.Show("Deze medewerker bestaat niet!");
                MakeErrorLog("Poging tot inloggen met verkeerde GebruikersID: " + GebruikersID, mname, "Aanmelden");
            }
        }

        private void CheckGebruikersID()
        {
            foreach (Employee e in Employees)
            {
                if (e.ID == Convert.ToInt32(GebruikersID))
                    IsID = true;
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
                    client.PostAsync("http://localhost:1092/api/Errorlog", new StringContent(errorlog, Encoding.UTF8, "application/json"));
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
