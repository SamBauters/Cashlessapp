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
    /// Interaction logic for mProduct.xaml
    /// </summary>
    public partial class mProduct : UserControl
    {
        public mProduct()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DisableControls();
        }
        private void DisableControls()
        {
            txtPrijs.IsEnabled = false;
            txtProductnaam.IsEnabled = false;
        }
        private void EnableControls()
        {
            txtPrijs.IsEnabled = true;
            txtProductnaam.IsEnabled = true;
        }

        private void btnNieuw_Click(object sender, RoutedEventArgs e)
        {
            EnableControls();
        }

        private void Bewerk_Click(object sender, RoutedEventArgs e)
        {
            EnableControls();
        }

        private void Verwijderen_Click(object sender, RoutedEventArgs e)
        {
            DisableControls();
        }

        private void Opslaan_Click(object sender, RoutedEventArgs e)
        {
            DisableControls();
        }
    }
}
