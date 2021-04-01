using System;
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
    /// Interaction logic for MediaPlayer.xaml
    /// </summary>
    public partial class MediaPlayer : UserControl
    {
        FlightController controller;
        int startling_line;
        public MediaPlayer()
        {
            InitializeComponent();
            controller = FlightController.GetInstance;
            controller.dataUpdated += Controller_dataUpdated;
            this.DataContext = this;
        }

        private void Controller_dataUpdated(object sender, FlightControllerEventArgs e)
        {
            this.startling_line = controller.startingLine;

            System.Diagnostics.Trace.WriteLine(e.GetData("aileron"));


        }

        private string getTotalTime()
        {
            TimeSpan t = TimeSpan.FromMilliseconds(controller.simulationSpeed * controller.getNumberOfLines());
            return string.Format("{0:D2}m:{1:D2}s:{2:D3}ms",
                t.Hours * 60 + t.Minutes, t.Seconds, t.Milliseconds);
        }

        private string getCurrentTime()
        {
            TimeSpan t = TimeSpan.FromMilliseconds(controller.simulationSpeed * controller.startingLine);
            return string.Format("{0:D2}m:{1:D2}s:{2:D3}ms",
                t.Hours * 60 + t.Minutes, t.Seconds, t.Milliseconds);
        }

        public string VM_currentTime
        {
            get
            {
                return getCurrentTime();

            }
        }
        public string VM_totalTime
        {
            get
            {           
                return getTotalTime();
            }
        }

        public void VM_play(int line)
        {
            controller.SimulateFlight(line);
        }
        public void VM_stop()
        {
            controller.StopSimulation();
        }
        public void VM_changeSpeed(int newSpeed)
        {
            controller.simulationSpeed = newSpeed;
        }
        public void VM_goto(int precent)
        {
            controller.StopSimulation();
            controller.SimulateFlight(precent); 
        }

        private void btn_play_Click(object sender, RoutedEventArgs e)
        {
            VM_play(0);
        }

    }
}
