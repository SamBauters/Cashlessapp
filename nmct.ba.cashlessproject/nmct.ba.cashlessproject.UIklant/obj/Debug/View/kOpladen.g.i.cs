﻿#pragma checksum "..\..\..\View\kOpladen.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8B6A7A085D4801C3D07ECB3AAF7666FA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using nmct.ba.cashlessproject.UIklant.ViewModel;


namespace nmct.ba.cashlessproject.UIklant.View {
    
    
    /// <summary>
    /// kOpladen
    /// </summary>
    public partial class kOpladen : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\View\kOpladen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Cijfers;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\View\kOpladen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstDevices;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\View\kOpladen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image pictureBoxMain;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\View\kOpladen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GegevensOpladen;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\View\kOpladen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbHuidigSaldo;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\View\kOpladen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbOpladen;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\View\kOpladen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbNieuwSaldo;
        
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
            System.Uri resourceLocater = new System.Uri("/nmct.ba.cashlessproject.UIklant;component/view/kopladen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\kOpladen.xaml"
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
            this.Cijfers = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.lstDevices = ((System.Windows.Controls.ListBox)(target));
            
            #line 35 "..\..\..\View\kOpladen.xaml"
            this.lstDevices.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lstDevices_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.pictureBoxMain = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.GegevensOpladen = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.txbHuidigSaldo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txbOpladen = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txbNieuwSaldo = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

