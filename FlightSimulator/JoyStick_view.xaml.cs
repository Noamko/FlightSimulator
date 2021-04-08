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
    /// Interaction logic for JoyStick_view.xaml
    /// </summary>
    public partial class JoyStick_view : UserControl
    {
        public JoyStick_view()
        {
            InitializeComponent();
        }

        private void JoyStick_Loaded(object sender, RoutedEventArgs e)
        {
            stick_controller.Width = _grid.ActualWidth /10;
            stick_controller.Height = stick_controller.Width;
        }

        public void setHeadPoition(int x, int y)
        {
            Canvas.SetLeft(stick_controller, x);
            Canvas.SetTop(stick_controller, y);
        }
    }
}
