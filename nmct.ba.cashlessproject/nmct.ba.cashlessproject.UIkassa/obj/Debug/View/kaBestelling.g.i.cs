﻿#pragma checksum "..\..\..\View\kaBestelling.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "40B1488400BB9C40D825846C687D65B7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GalaSoft.MvvmLight.Command;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using nmct.ba.cashlessproject.UIkassa.Converter;
using nmct.ba.cashlessproject.UIkassa.ViewModel;


namespace nmct.ba.cashlessproject.UIkassa.View {
    
    
    /// <summary>
    /// kaBestelling
    /// </summary>
    public partial class kaBestelling : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 47 "..\..\..\View\kaBestelling.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLeesEID;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\View\kaBestelling.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdKlant;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\View\kaBestelling.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgKlant;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\View\kaBestelling.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblNaam;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\View\kaBestelling.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbNaam;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\View\kaBestelling.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblBalans;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\View\kaBestelling.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbSaldo;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\View\kaBestelling.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbBestelling;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\View\kaBestelling.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lstBestelling;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\View\kaBestelling.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridView grdBestelling;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\View\kaBestelling.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVerwijderen;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\View\kaBestelling.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox icProducten;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\View\kaBestelling.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtProduct;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\View\kaBestelling.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAantal;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\View\kaBestelling.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPlus;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\View\kaBestelling.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMin;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\View\kaBestelling.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnToevoegen;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\View\kaBestelling.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAfrekenen;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/nmct.ba.cashlessproject.UIkassa;component/view/kabestelling.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\kaBestelling.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\View\kaBestelling.xaml"
            ((nmct.ba.cashlessproject.UIkassa.View.kaBestelling)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnLeesEID = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.grdKlant = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.imgKlant = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.lblNaam = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.txbNaam = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.lblBalans = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.txbSaldo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.txbBestelling = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.lstBestelling = ((System.Windows.Controls.ListView)(target));
            return;
            case 11:
            this.grdBestelling = ((System.Windows.Controls.GridView)(target));
            return;
            case 12:
            this.btnVerwijderen = ((System.Windows.Controls.Button)(target));
            return;
            case 13:
            this.icProducten = ((System.Windows.Controls.ListBox)(target));
            return;
            case 14:
            this.txtProduct = ((System.Windows.Controls.TextBox)(target));
            return;
            case 15:
            this.txtAantal = ((System.Windows.Controls.TextBox)(target));
            return;
            case 16:
            this.btnPlus = ((System.Windows.Controls.Button)(target));
            return;
            case 17:
            this.btnMin = ((System.Windows.Controls.Button)(target));
            return;
            case 18:
            this.btnToevoegen = ((System.Windows.Controls.Button)(target));
            return;
            case 19:
            this.btnAfrekenen = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

