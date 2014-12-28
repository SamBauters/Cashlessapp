using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Thinktecture.IdentityModel.Client;

namespace nmct.ba.cashlessproject.UImanagement.ViewModel
{
    class ApplicationVM : ObservableObject
    {
        public static TokenResponse token = null;
        public static string username = string.Empty;
        public ApplicationVM()
        {
            Pages.Add(new mAanmeldenVM());
            Pages.Add(new mMedewerkersVM());
            pages.Add(new mKlantenVM());
            pages.Add(new mKassaVM());
            pages.Add(new mProductVM());
            pages.Add(new mStatistiekenVM());
            pages.Add(new mAccountVM());
            CurrentPage = Pages[0];
        }

        private object currentPage;
        public object CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; OnPropertyChanged("CurrentPage"); }
        }

        private List<IPage> pages;
        public List<IPage> Pages
        {
            get
            {
                if (pages == null)
                    pages = new List<IPage>();
                return pages;
            }
        }

        public ICommand ChangePageCommand
        {
            get { return new RelayCommand<IPage>(ChangePage); }
        }

        public void ChangePage(IPage page)
        {
            if (token != null)
                CurrentPage = page;
        }

        public ICommand AfmeldenCMD
        {
            get { return new RelayCommand(Afmelden); }
        }

        private void Afmelden()
        {
            ChangePage(pages[0]);
            token = null;
        }

    }
}
