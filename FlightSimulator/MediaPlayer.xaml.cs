using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for MediaPlayer.xaml
    /// </summary>
    public partial class MediaPlayer : UserControl
    {
        mediaController_VM vm;

        public MediaPlayer()
        {
            InitializeComponent();
            vm = new mediaController_VM();
            this.DataContext = vm;

        }

   //     private void Controller_dataUpdated(object sender, FlightControllerEventArgs e)
  //      {
    //        this.startling_line = controller.startingLine;

      //      System.Diagnostics.Trace.WriteLine(e.GetData("aileron"));



        private void btn_play_Click(object sender, RoutedEventArgs e)
        {
            vm.VM_play();
        }

        private void btn_pause_Click(object sender, RoutedEventArgs e)
        {
            vm.VM_pause();
        }

        private void btn_gotoLine_Click(object sender, RoutedEventArgs e)
        {
            int percent = int.Parse(tb_line.Text);
            vm.VM_goto(percent);
        }

        private void btn_setSpeed_Click(object sender, RoutedEventArgs e)
        {
            double newSpeed = double.Parse(tb_setSpeed.Text);
            vm.VM_setSpeed(newSpeed);
        }

        private void timeline_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Trace.WriteLine(timeline_slider.Value);
        }

        private void timeline_slider_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Trace.WriteLine(timeline_slider.Maximum);
        }
    }
}
