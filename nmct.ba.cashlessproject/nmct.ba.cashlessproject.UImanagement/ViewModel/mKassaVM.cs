﻿using GalaSoft.MvvmLight.Command;
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

        private RegistersKlant _selectedKassa;
        public RegistersKlant SelectedKassa
        {
            get { return _selectedKassa; }
            set { _selectedKassa = value; OnPropertyChanged("SelectedKassa"); }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("Status"); }
        }

        private async void UpdateKlant()
        {
            using (HttpClient client = new HttpClient())
            {
                RegistersKlant kl = SelectedKassa;

                //je kunt geen object over het internet sturen, enkel xml of json (kort gezegd)

                //hier: omzetten van string naar json-formaat
                string input = JsonConvert.SerializeObject(kl);

                //Put()-method wordt aangesproken
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                HttpResponseMessage response = await client.PutAsync("http://localhost:1092/api/Klant", new StringContent(input, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    GetKassas();
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

        public void ClickSave()
        {
            if (Status == "Update")
            {
                UpdateKlant();
            }

            else if (Status == "Add")
            {
                //AddKlant();
            }
        }

        public ICommand ClickSaveCommand
        {
            get { return new RelayCommand(ClickSave); }
        }


    }
}
