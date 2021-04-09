using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FlightController flightController;
        FileHandler fileHandler;
        public MainWindow()
        {
            InitializeComponent();
            flightController = FlightController.GetInstance;
            fileHandler = new FileHandler();

            passData_VM passdata = new passData_VM();
            airspeed_view.SetVM(passdata);
            altitude_view.SetVM(passdata);
            direction_view.SetVM(passdata);
            yawRollPitch_view.SetVM(passdata);
            joystick.SetVM(passdata);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            FileLoader fLoader = new FileLoader(fileHandler);
            Nullable<bool> res = fLoader.ShowDialog();
            if (res == true)
            {
                this.IsEnabled = true;
                string[] names = getNames();
                flightController.loadCSV(fileHandler.csvPath, names) ;
                StartFlightGear();
            }

        }
        private string[] getNames()
        {
            string str = System.IO.File.ReadLines(fileHandler.anomalyCsvPath).First();
            string[] split = str.Split(",");
            string[] output = new string[split.Length];
            for (int i = 0; i < split.Length; i++)
            {
                string name = split[i];
                split[i] = "";
                if (!output.Contains(name))
                    output[i] = name;
                else output[i] = name + "_2";
            }
            return output;

        }

        public void StartFlightGear()
        {
            if (fileHandler.fgPath == null)
                throw new NullReferenceException("FlightGear Path isn't initialized");
            System.Diagnostics.Process.Start(fileHandler.fgPath, "--launcher");
        }

        private void FlightController_dataChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("WOW");
        }
    }
}
