using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace nmct.ba.cashlessproject.UImanagement.View
{
    /// <summary>
    /// Interaction logic for mMedewerkers.xaml
    /// </summary>
    public partial class mMedewerkers : UserControl
    {
        public mMedewerkers()
        {
            InitializeComponent();
        }

        private void lstMedewerkers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisableControls();
        }

        private void DisableControls()
        {
            txtVoornaam.IsEnabled = false;
            txtAchternaam.IsEnabled = false;
            txtAdres.IsEnabled = false;
            txtEmail.IsEnabled = false;
            txtPhone.IsEnabled = false;
        }
        private void EnableControls()
        {
            txtVoornaam.IsEnabled = true;
            txtAchternaam.IsEnabled = true;
            txtAdres.IsEnabled = true;
            txtEmail.IsEnabled = true;
            txtPhone.IsEnabled = true;
        }
        private void btnNieuw_Click(object sender, RoutedEventArgs e)
        {
            EnableControls();
        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            DisableControls();
        }

        private void btnVerwijder_Click(object sender, RoutedEventArgs e)
        {
            DisableControls();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EnableControls();
        }


    }
}
