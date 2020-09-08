﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "488B36AD986D425C39CA8B83ED2C162F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using System.Windows.Forms;
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
using UFO.Converters;
using UFO.Properties;


namespace UFO {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 19 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu menu;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem WSLightButton;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem WSDarkButton;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ShowPhotoSearchView;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker date_start;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker date_end;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbNdb;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbFamily;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbName;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid vGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/UFO;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.menu = ((System.Windows.Controls.Menu)(target));
            return;
            case 2:
            
            #line 24 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.BSearch_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 25 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.bClear_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 28 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DataBaseLink_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.WSLightButton = ((System.Windows.Controls.MenuItem)(target));
            
            #line 30 "..\..\MainWindow.xaml"
            this.WSLightButton.Click += new System.Windows.RoutedEventHandler(this.ThemeChangeLight);
            
            #line default
            #line hidden
            return;
            case 6:
            this.WSDarkButton = ((System.Windows.Controls.MenuItem)(target));
            
            #line 31 "..\..\MainWindow.xaml"
            this.WSDarkButton.Click += new System.Windows.RoutedEventHandler(this.ThemeChangeDark);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 35 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Help_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 37 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.About_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 42 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BSearch_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 48 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.bClear_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.ShowPhotoSearchView = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\MainWindow.xaml"
            this.ShowPhotoSearchView.Click += new System.Windows.RoutedEventHandler(this.ShowPhotoSearchView_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.date_start = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 13:
            this.date_end = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 14:
            this.cbNdb = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 15:
            this.tbFamily = ((System.Windows.Controls.TextBox)(target));
            return;
            case 16:
            this.tbName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 17:
            this.vGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 141 "..\..\MainWindow.xaml"
            this.vGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.vGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 18:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.MouseDoubleClickEvent;
            
            #line 145 "..\..\MainWindow.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.vGrid_MouseDoubleClick);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}

