﻿#pragma checksum "..\..\..\..\FileLoader.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3EF228DC8CCF25CEA86A909F21DDCF6BEC339F16"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FlightSimulator;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace FlightSimulator {
    
    
    /// <summary>
    /// FileLoader
    /// </summary>
    public partial class FileLoader : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\FileLoader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_xmlPath;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\FileLoader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_openXml;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\FileLoader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_csvPath;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\FileLoader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_opebCSV;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\FileLoader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_exePath;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\FileLoader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_opebEXE;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\FileLoader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_anomaliesPath;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\FileLoader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_opebANOMALIES;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\FileLoader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_submit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FlightSimulator;component/fileloader.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\FileLoader.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.tb_xmlPath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.btn_openXml = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\FileLoader.xaml"
            this.btn_openXml.Click += new System.Windows.RoutedEventHandler(this.btn_openXml_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tb_csvPath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btn_opebCSV = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\FileLoader.xaml"
            this.btn_opebCSV.Click += new System.Windows.RoutedEventHandler(this.btn_opebCSV_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tb_exePath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btn_opebEXE = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\..\FileLoader.xaml"
            this.btn_opebEXE.Click += new System.Windows.RoutedEventHandler(this.btn_opebEXE_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tb_anomaliesPath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btn_opebANOMALIES = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\FileLoader.xaml"
            this.btn_opebANOMALIES.Click += new System.Windows.RoutedEventHandler(this.btn_opebANOMALIES_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btn_submit = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\..\FileLoader.xaml"
            this.btn_submit.Click += new System.Windows.RoutedEventHandler(this.btn_submit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

