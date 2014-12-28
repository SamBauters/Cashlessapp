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

namespace nmct.ba.cashlessproject.UIklant.View
{
    /// <summary>
    /// Interaction logic for kRegistrerenLogin.xaml
    /// </summary>
    public partial class kRegistrerenLogin : UserControl
    {
        public kRegistrerenLogin()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DisableControls();
        }

        private void DisableControls()
        {
            txtNaam.IsEnabled = false;
            txtStad.IsEnabled = false;
            txtStraat.IsEnabled = false;
            txtVoornaam.IsEnabled = false;
        }
    }
}
