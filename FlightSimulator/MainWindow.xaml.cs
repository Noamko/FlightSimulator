using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
        FileLoader fLoader;
        MainWindow_VM vm;
        public MainWindow()
        {
            InitializeComponent();
            flightController = FlightController.GetInstance;
            fileHandler = new FileHandler();
            vm = new MainWindow_VM();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            fLoader = new FileLoader(fileHandler);
            Nullable<bool> res = fLoader.ShowDialog();
            if (res == true)
            {
                this.IsEnabled = true;
                flightController.loadCSV(fileHandler.csvPath);
                //vm.StartFlightGear(fileHandler.fgPath);
                
                AnomalyDetector dt  = new AnomalyDetector(); //TODO make dynamic names from xml
                                                             //string[] names = new string[41];
                string names = "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,32,33,34,35,36,37,38,39,40,41\0";

                dt.LearnNormal(names,fileHandler.csvPath);

                string s = @"C:\Users\noamk\Desktop\anomaly_flight.csv";
                dt.Detect(names, s);
                Trace.WriteLine(dt.GetDiscription(2));
            }

        }
    }
}
