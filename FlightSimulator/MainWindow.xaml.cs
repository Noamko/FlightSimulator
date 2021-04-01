using System;
using System.Collections.Generic;
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
            flightController = new FlightController();
            fileHandler = new FileHandler();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            FileLoader fLoader = new FileLoader(fileHandler);
            Nullable<bool> res = fLoader.ShowDialog();
            if (res == true)
            {
                this.IsEnabled = true;
                System.Diagnostics.Trace.WriteLine(fileHandler.csvPath);
            }
        }

        private void FlightController_dataChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("WOW");
        }
    }
}
