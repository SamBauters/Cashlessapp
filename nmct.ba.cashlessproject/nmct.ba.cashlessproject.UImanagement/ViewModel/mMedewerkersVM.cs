using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using nmct.ba.cashlessproject.model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace nmct.ba.cashlessproject.UImanagement.ViewModel
{
    class mMedewerkersVM : ObservableObject, IPage
    {
        public mMedewerkersVM()
        {
            if(ApplicationVM.token != null)
            GetMedewerkers();
        }
        public string Name
        {
            get { return "Medewerker"; }
        }

        private ObservableCollection<Employee> _medewerkers;

        public ObservableCollection<Employee> Medewerkers
        {
            get { return _medewerkers; }
            set { _medewerkers = value; OnPropertyChanged("Medewerkers"); }
        }

        private async void GetMedewerkers()
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                HttpResponseMessage response = await client.GetAsync("http://localhost:1092/api/Medewerker");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Medewerkers = JsonConvert.DeserializeObject<ObservableCollection<Employee>>(json);
                }
            }
        }

        private Employee _selectedMedewerker;
        public Employee SelectedMedewerker
        {
            get { return _selectedMedewerker; }
            set { _selectedMedewerker = value; OnPropertyChanged("SelectedMedewerker"); }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("Status"); }
        }

        private async void UpdateMedewerker()
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                Employee emp = SelectedMedewerker;
                string input = JsonConvert.SerializeObject(emp);
                HttpResponseMessage response = await client.PutAsync("http://localhost:1092/api/Medewerker", new StringContent(input, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    GetMedewerkers();
                }
            }
        }

        public async void AddMedewerker()
        {
            Employee newEmployee = SelectedMedewerker;
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                string emp = JsonConvert.SerializeObject(newEmployee);
                HttpResponseMessage response = await client.PostAsync("http://localhost:1092/api/Medewerker", new StringContent(emp, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    GetMedewerkers();
                }
            }
        }

        public async void DeleteMedewerker()
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                HttpResponseMessage response = await client.DeleteAsync("http://localhost:1092/api/Medewerker/" + SelectedMedewerker.ID);
                if (response.IsSuccessStatusCode)
                {
                    GetMedewerkers();
                }
            }
        }

        public void SetStatusToUpdate()
        {
            Status = "Update";
        }

        public ICommand SetStatusToUpdateCommand
        {
            get { return new RelayCommand(SetStatusToUpdate); }
        }
        public ICommand DeleteEmployeeCommand
        {
            get { return new RelayCommand(DeleteMedewerker); }
        }
        public void SetStatusToAdd()
        {
            Employee emp = new Employee();
            Medewerkers.Add(emp);
            SelectedMedewerker = emp;

            Status = "Add";
        }

        public ICommand SetStatusToAddCommand
        {
            get { return new RelayCommand(SetStatusToAdd); }
        }

        public void ClickSave()
        {
            if (Status == "Update")
            {
                UpdateMedewerker();
            }

            else if (Status == "Add")
            {
                AddMedewerker();
            }
        }

        public ICommand ClickSaveCommand
        {
            get { return new RelayCommand(ClickSave); }
        }
    }
}
