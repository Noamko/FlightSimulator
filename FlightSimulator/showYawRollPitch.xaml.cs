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
    /// Interaction logic for showYawRollPitch.xaml
    /// </summary>
    public partial class showYawRollPitch : UserControl
    {
        passData_VM vm;
        //roll_deg = roll
        //pitch_deg= pitch
        //side-slip-deg = yaw
        public showYawRollPitch()
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
