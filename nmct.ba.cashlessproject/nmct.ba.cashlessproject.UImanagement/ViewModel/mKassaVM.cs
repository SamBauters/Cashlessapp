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
    class mKassaVM : ObservableObject, IPage
    {
        public mKassaVM()
        {
            if (ApplicationVM.token != null)
                GetKassas();
        }
        public string Name
        {
            get { return "Kassa"; }
        }
        private ObservableCollection<RegistersKlant> _kassa;

        public ObservableCollection<RegistersKlant> Kassa
        {
            get { return _kassa; }
            set { _kassa = value; OnPropertyChanged("Kassa"); }
        }

        private ObservableCollection<Employee> _employees;

        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set { _employees = value; OnPropertyChanged("Employees"); }
        }

        private async void GetKassas()
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                HttpResponseMessage response = await client.GetAsync("http://localhost:1092/api/Kassa");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Kassa = JsonConvert.DeserializeObject<ObservableCollection<RegistersKlant>>(json);
                }
            }
        }

        private async void GetEmployeesByRegister()
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                HttpResponseMessage response = await client.GetAsync("http://localhost:1092/api/Medewerker?registerID=r" + SelectedKassa.ID);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Employees = JsonConvert.DeserializeObject<ObservableCollection<Employee>>(json);
                }
            }
        }

        private RegistersKlant _selectedKassa;
        public RegistersKlant SelectedKassa
        {
            get { return _selectedKassa; }
            set { _selectedKassa = value; OnPropertyChanged("SelectedKassa"); }
        }

        private Register_Employee _selectedEmployee;
        public Register_Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set { _selectedEmployee = value; OnPropertyChanged("SelectedEmployee"); }
        }
        public ICommand GetEmployeesCommand
        {
            get { return new RelayCommand(GetEmployees); }
        }
        public void GetEmployees()
        {
            GetEmployeesByRegister();
        }


    }
}
