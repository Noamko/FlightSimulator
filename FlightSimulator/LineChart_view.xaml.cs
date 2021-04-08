﻿using System;
using System.Windows.Controls;
using System.ComponentModel;
using OxyPlot;
using OxyPlot.Wpf;
using OxyPlot.Axes;

namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for LineChart_view.xaml
    /// </summary>
    public partial class LineChart_view : UserControl
    {
        lineChart_VM vm;

        public LineChart_view()
        {
            InitializeComponent();
            vm = new lineChart_VM();
            DataContext = vm;
            vm.PropertyChanged += Update;
          //  PlotModel pm = new PlotModel();
           //pm.Axes.Add(plot.Series);

            plot.Axes.Add(new OxyPlot.Wpf.LinearAxis
            {
                //Other properties here
                Position = AxisPosition.Bottom,
                LabelFormatter = formatter
            }) ;

            plotCorrlated.Axes.Add(new OxyPlot.Wpf.LinearAxis
            {
                //Other properties here
                Position = AxisPosition.Bottom,
                LabelFormatter = formatter
            });


        }

        private string formatter(double arg)
        {
        if (arg <= 0)
            return arg.ToString();
        TimeSpan t = TimeSpan.FromMilliseconds(arg );
        return string.Format("{0:D2}m:{1:D2}s", t.Hours * 60 + t.Minutes, t.Seconds);
        }


        private void Update(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("dataChanged"))
            {
                plot.InvalidatePlot(true);
                plotCorrlated.InvalidatePlot(true);
                linear_reg.InvalidatePlot(true);
               // test.InvalidatePlot(true);
            }


        }
        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (Charts.SelectedItem != null)
            {
                plot.Title = Charts.SelectedItem.ToString();
                vm.updateList((string)Charts.SelectedItem);
            }

        }

        //   private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //    {
        //     }


    }
}