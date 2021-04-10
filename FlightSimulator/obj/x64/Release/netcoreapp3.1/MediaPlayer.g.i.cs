﻿#pragma checksum "..\..\..\..\MediaPlayer.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1DE6E8B3262D660955CC5AB883F920B85183BA38"
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
    /// MediaPlayer
    /// </summary>
    public partial class MediaPlayer : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\MediaPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_play;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\MediaPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_pause;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\MediaPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_totalTime;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\MediaPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_currebtTime;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\MediaPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider timeline_slider;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\MediaPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_line;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\MediaPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_gotoLine;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\MediaPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_setSpeed;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\MediaPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_setSpeed;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FlightSimulator;V1.0.0.0;component/mediaplayer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MediaPlayer.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btn_play = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\MediaPlayer.xaml"
            this.btn_play.Click += new System.Windows.RoutedEventHandler(this.btn_play_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_pause = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\MediaPlayer.xaml"
            this.btn_pause.Click += new System.Windows.RoutedEventHandler(this.btn_pause_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txt_totalTime = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.txt_currebtTime = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.timeline_slider = ((System.Windows.Controls.Slider)(target));
            
            #line 22 "..\..\..\..\MediaPlayer.xaml"
            this.timeline_slider.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.timeline_slider_MouseDown);
            
            #line default
            #line hidden
            
            #line 22 "..\..\..\..\MediaPlayer.xaml"
            this.timeline_slider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.timeline_slider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.tb_line = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btn_gotoLine = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\MediaPlayer.xaml"
            this.btn_gotoLine.Click += new System.Windows.RoutedEventHandler(this.btn_gotoLine_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.tb_setSpeed = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.btn_setSpeed = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\MediaPlayer.xaml"
            this.btn_setSpeed.Click += new System.Windows.RoutedEventHandler(this.btn_setSpeed_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

