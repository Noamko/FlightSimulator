﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for showAltitude.xaml
    /// </summary>
    public partial class showAltitude : UserControl
    {
        passData_VM vm;
        //it presents the height of the plane.
        public showAltitude()
        {
            InitializeComponent();
        }
        public void SetVM(passData_VM vm)
        {
            this.vm = vm;
            DataContext = vm;
        }
    }
}