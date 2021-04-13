using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for AnomalyGraphWindow.xaml
    /// </summary>
    public partial class AnomalyGraphWindow : Window
    {
        public AnomalyGraphWindow()
        {
            InitializeComponent();
            anomaly_uc.Visibility = Visibility.Hidden;
        }

        public void LoadCSV(string normal, string anomaly)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                anomaly_uc.LoadCSVS(normal, anomaly);
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    anomaly_uc.Visibility = Visibility.Visible;
                    txt_loading.Visibility = Visibility.Hidden;
                }));
            }).Start();
        }
    }
}
