﻿#pragma checksum "..\..\PremiumsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1D781C448CF898985F7A3F9F1394918C260FD57428FDD39925F93003CB58FA03"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using filmography;


namespace filmography {
    
    
    /// <summary>
    /// PremiumsPage
    /// </summary>
    public partial class PremiumsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\PremiumsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid premiumsGrid;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\PremiumsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas AddingForm;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\PremiumsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox addName;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\PremiumsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox addCountry;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\PremiumsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox addYear;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\PremiumsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox addNameActor;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\PremiumsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox addNameFilm;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\PremiumsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox addNameNomination;
        
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
            System.Uri resourceLocater = new System.Uri("/filmography;component/premiumspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PremiumsPage.xaml"
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
            this.premiumsGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            
            #line 38 "..\..\PremiumsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_AddingForm);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 39 "..\..\PremiumsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_EditingForm);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 40 "..\..\PremiumsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_DeletingForm);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AddingForm = ((System.Windows.Controls.Canvas)(target));
            return;
            case 6:
            this.addName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.addCountry = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.addYear = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.addNameActor = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.addNameFilm = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.addNameNomination = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 12:
            
            #line 56 "..\..\PremiumsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Adding);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 57 "..\..\PremiumsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Cancel);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

