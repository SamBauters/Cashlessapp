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

namespace nmct.ba.cashlessproject.UIkassa.View
{
    /// <summary>
    /// Interaction logic for kaInlog.xaml
    /// </summary>
    public partial class kaInlog : UserControl
    {
        public kaInlog()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DisableControls();
        }

        private void DisableControls()
        {
            txtGebruikerID.IsEnabled = false;
        }
    }
}
