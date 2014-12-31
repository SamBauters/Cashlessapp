using System;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Encrypt;
using GalaSoft.MvvmLight.Command;
using nmct.ba.cashlessproject.model;
using Newtonsoft.Json;

namespace nmct.ba.cashlessproject.UImanagement.ViewModel
{
    class mAccountVM : ObservableObject, IPage
    {
        public string Name
        {
            get { return "Account"; }
        }

        public mAccountVM()
        {

        }
        #region props
        public string Username
        {
            get { return ApplicationVM.username; }
        }

        private string _oud;

        public string OudWachtwoord
        {
            get { return _oud; }
            set { _oud = value; }
        }

        private string _nieuw;

        public string NieuwWachtwoord
        {
            get { return _nieuw; }
            set { _nieuw = value; }
        }

        private string _bevestig;

        public string BevestigWachtwoord
        {
            get { return _bevestig; }
            set { _bevestig = value; }
        }
        #endregion

        public ICommand SavePasswordCommand
        {
            get
            {
                return new RelayCommand(SavePassword);
            }
        }

        private async void ChangePassword()
        {
            Organisations o = new Organisations();
            o.Login = Cryptography.Encrypt(Username);
            o.Password = Cryptography.Encrypt(NieuwWachtwoord);
            o.DbLogin = o.Login;
            o.DbPassword = o.Password;

            string input = JsonConvert.SerializeObject(o);

            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                HttpResponseMessage response = await client.PutAsync("http://localhost:1092/api/Organisation", new StringContent(input, Encoding.UTF8, "application/json"));

                MessageBox.Show("Wachtwoord succesvol gewijzigd!");

                if (!response.IsSuccessStatusCode)
                    Console.WriteLine("Save Organisation Error");
            }
        }

        private async void GetCheckAccount()
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                HttpResponseMessage response = await client.GetAsync("http://localhost:1092/api/Organisation?username=" + Cryptography.Encrypt(Username) + "&password=" + Cryptography.Encrypt(OudWachtwoord));

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    bool IsAccount = JsonConvert.DeserializeObject<bool>(json);

                    if (IsAccount)
                    {
                        if (NieuwWachtwoord.Equals(BevestigWachtwoord))
                            ChangePassword();
                    }
                }
            }
        }

        public void SavePassword()
        {
            GetCheckAccount();
        }
    }
}
