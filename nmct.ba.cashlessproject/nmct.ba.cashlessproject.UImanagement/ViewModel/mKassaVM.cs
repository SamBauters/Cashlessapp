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
        private ObservableCollection<Registers> _kassa;

        public ObservableCollection<Registers> Kassa
        {
            get { return _kassa; }
            set { _kassa = value; OnPropertyChanged("Kassa"); }
        }

        private ObservableCollection<Register_Employee> _registersEmployees;

        public ObservableCollection<Register_Employee> RegistersEmployees
        {
            get { return _registersEmployees; }
            set { _registersEmployees = value; OnPropertyChanged("RegistersEmployees"); }
        }

        private Registers _selectedKassa;
        public Registers SelectedKassa
        {
            get { return _selectedKassa; }
            set { _selectedKassa = value; OnPropertyChanged("SelectedKassa"); }
        }

        private Employee _selectedEmployee;

        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set { _selectedEmployee = value; OnPropertyChanged("SelectedEmployee"); }
        }

        private Register_Employee _selectedRegisterEmployee;

        public Register_Employee SelectedRegisterEmployee
        {
            get { return _selectedRegisterEmployee; }
            set { _selectedRegisterEmployee = value; OnPropertyChanged("SelectedRegisterEmployee"); }
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
                    Kassa = JsonConvert.DeserializeObject<ObservableCollection<Registers>>(json);
                }
            }
        }

        private async void GetEmployeesByRegister()
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                HttpResponseMessage response = await client.GetAsync("http://localhost:1092/api/Medewerker?rID=r" + SelectedKassa.ID);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    RegistersEmployees = JsonConvert.DeserializeObject<ObservableCollection<Register_Employee>>(json);

                    ObservableCollection<Employee> employeeList = new ObservableCollection<Employee>();

                    foreach (Register_Employee re in RegistersEmployees)
                    {
                        employeeList.Add(re.Employee);
                    }

                    Employees = employeeList;
                }
            }
        }


        public ICommand GetEmployeesCommand
        {
            get { return new RelayCommand(GetEmployees); }
        }
        public void GetEmployees()
        {
            GetEmployeesByRegister();
        }

        public ICommand GetRegister_EmployeeCommand
        {
            get { return new RelayCommand(GetRegister_Employee); }
        }

        public void GetRegister_Employee()
        {
            if (SelectedEmployee != null)
            {
                foreach (Register_Employee re in RegistersEmployees)
                {
                    if (SelectedKassa.ID.Equals(re.Register.ID) && SelectedEmployee.ID.Equals(re.Employee.ID))
                    {
                        SelectedRegisterEmployee = re;
                    }
                }
            }
        }



    }
}
