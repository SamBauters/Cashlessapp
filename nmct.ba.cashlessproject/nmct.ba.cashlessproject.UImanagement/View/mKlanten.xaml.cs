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
    /// Interaction logic for mKlanten.xaml
    /// </summary>
    public partial class mKlanten : UserControl
    {
        public mKlanten()
        {
            InitializeComponent();
        }

        private void DisableControls()
        {
            txtNaam.IsEnabled = false;
            txtBalans.IsEnabled = false;
            txtAdres.IsEnabled = false;
        }
        private void EnableControls()
        {
            txtNaam.IsEnabled = true;
            txtBalans.IsEnabled = true;
            txtAdres.IsEnabled = true;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DisableControls();
        }

        private void btnBewerk_Click(object sender, RoutedEventArgs e)
        {
            EnableControls();
        }

        private void BtnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            DisableControls();
        }

        private void BtnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            DisableControls();
        }
    }
}
