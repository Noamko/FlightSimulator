﻿#pragma checksum "..\..\..\..\JoyStick_view.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7DF584A577DE22E6CF31113AC0F3DF07F372D9A4"
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
    /// JoyStick_view
    /// </summary>
    public partial class JoyStick_view : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\JoyStick_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FlightSimulator.JoyStick_view JoyStick;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\..\JoyStick_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid _grid;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\JoyStick_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition grid_top_height;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\JoyStick_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition grid_center_height;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\JoyStick_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas cnv;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\JoyStick_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Line stick_rod;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\JoyStick_view.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse stick_controller;
        
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
            System.Uri resourceLocater = new System.Uri("/FlightSimulator;component/joystick_view.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\JoyStick_view.xaml"
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
            this.JoyStick = ((FlightSimulator.JoyStick_view)(target));
            
            #line 8 "..\..\..\..\JoyStick_view.xaml"
            this.JoyStick.Loaded += new System.Windows.RoutedEventHandler(this.JoyStick_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this._grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.grid_top_height = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 4:
            this.grid_center_height = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 5:
            this.cnv = ((System.Windows.Controls.Canvas)(target));
            return;
            case 6:
            this.stick_rod = ((System.Windows.Shapes.Line)(target));
            return;
            case 7:
            this.stick_controller = ((System.Windows.Shapes.Ellipse)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

