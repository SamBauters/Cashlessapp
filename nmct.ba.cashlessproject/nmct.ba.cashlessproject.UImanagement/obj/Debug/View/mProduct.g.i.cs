﻿#pragma checksum "..\..\..\View\mProduct.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "170D7E2CC3C388AF567189E1E80FA33A"
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
using nmct.ba.cashlessproject.UImanagement.ViewModel;


namespace nmct.ba.cashlessproject.UImanagement.View {
    
    
    /// <summary>
    /// mProduct
    /// </summary>
    public partial class mProduct : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\View\mProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Gegevens;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\View\mProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtProductnaam;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\View\mProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPrijs;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\View\mProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Buttons;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\View\mProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNieuw;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\View\mProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Bewerk;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\View\mProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Verwijderen;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\View\mProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Opslaan;
        
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
            System.Uri resourceLocater = new System.Uri("/nmct.ba.cashlessproject.UImanagement;component/view/mproduct.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\mProduct.xaml"
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
            
            #line 8 "..\..\..\View\mProduct.xaml"
            ((nmct.ba.cashlessproject.UImanagement.View.mProduct)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Gegevens = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.txtProductnaam = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtPrijs = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Buttons = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.btnNieuw = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\View\mProduct.xaml"
            this.btnNieuw.Click += new System.Windows.RoutedEventHandler(this.btnNieuw_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Bewerk = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\View\mProduct.xaml"
            this.Bewerk.Click += new System.Windows.RoutedEventHandler(this.Bewerk_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Verwijderen = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\View\mProduct.xaml"
            this.Verwijderen.Click += new System.Windows.RoutedEventHandler(this.Verwijderen_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Opslaan = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\View\mProduct.xaml"
            this.Opslaan.Click += new System.Windows.RoutedEventHandler(this.Opslaan_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

