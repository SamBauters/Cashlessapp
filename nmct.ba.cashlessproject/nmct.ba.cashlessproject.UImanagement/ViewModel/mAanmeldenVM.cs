using System;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Thinktecture.IdentityModel.Client;

namespace nmct.ba.cashlessproject.UImanagement.ViewModel
{
    class mAanmeldenVM : ObservableObject, IPage
    {
        public string Name
        {
            get { return "Login"; }
        }

        #region props
        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged("Username"); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("Password"); }
        }

        private string _error;
        public string Error
        {
            get { return _error; }
            set { _error = value; OnPropertyChanged("Error"); }
        }
        #endregion


        public ICommand LoginCommand
        {
            get { return new RelayCommand(Login); }
        }

        private void Login()
        {
            ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
            ApplicationVM.token = GetToken();

            if (!ApplicationVM.token.IsError)
            {
                ApplicationVM.username = Username;
                if (appvm != null) 
                    appvm.ChangePage(new mMedewerkersVM());
            }
            else
                Error = "Gebruikersnaam of paswoord kloppen niet";
        }

        private TokenResponse GetToken()
        {
            OAuth2Client client = new OAuth2Client(new Uri("http://localhost:1092/token"));
            return client.RequestResourceOwnerPasswordAsync(Username, Password).Result;
        }
    }
}
