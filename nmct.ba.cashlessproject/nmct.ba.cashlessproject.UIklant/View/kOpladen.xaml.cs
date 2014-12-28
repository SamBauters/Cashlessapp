﻿using System;
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
    /// Interaction logic for kOpladen.xaml
    /// </summary>
    public partial class kOpladen : UserControl
    {
        public kOpladen()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DisableControls();
        }

        private void DisableControls()
        {
            txtAdres.IsEnabled = false;
            txtBedrag.IsEnabled = false;
            txtHuidigSaldo.IsEnabled = false;
            txtNaam.IsEnabled = false;
            txtNieuwSaldo.IsEnabled = false;
        }
    }
}
