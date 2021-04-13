using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AnomalyUC.xaml
    /// </summary>
    public partial class AnomalyUC : UserControl
    {
        PlotModel plotModel;
        Anomalies_vm anomalies_Vm;
        public AnomalyUC()
        {
            InitializeComponent();
            plotModel = initModel();
            plot.Model = plotModel;
        }

        PlotModel initModel()
        {
            PlotModel model = new PlotModel { Title = "Example" };
            model.LegendPosition = LegendPosition.RightBottom;
            model.LegendPlacement = LegendPlacement.Outside;
            model.LegendOrientation = LegendOrientation.Horizontal;
            var Yaxis = new OxyPlot.Axes.LinearAxis();
            var XAxis = new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Bottom };
            model.Axes.Add(Yaxis);
            model.Axes.Add(XAxis);
          //  plotModel = model;
            return model;
        }

        //private void Model_TrackerChanged(object sender, TrackerEventArgs e)
        //{
        //    //try
        //    //{
        //        e.HitResult.Text = "hi";
        //        System.Diagnostics.Trace.WriteLine(e.HitResult.Text);
        //        System.Diagnostics.Trace.WriteLine(e.HitResult.YAxis);
        //    }
        //    catch
        //    {

        //    }
        //}

        public double getValue(string func, double x)
        {
            string funcCopy = func;
            string result;
            funcCopy = funcCopy.Replace("x", x.ToString());
            funcCopy = funcCopy.Replace("X", x.ToString());
            NCalc.Expression e = new NCalc.Expression(funcCopy);
            result = e.Evaluate().ToString();
            return Double.Parse(result);
            //return 20.0;
        }

        public FunctionSeries addFunc(string func, double max, double min, double interval,float addX, float addY)
        {
            FunctionSeries serie = new FunctionSeries();
            for (double x = min; x <= max; x += interval)
            {

                //    for (double y = min; y <= max; y += interval)
                //    {
                DataPoint data = new DataPoint(x + addX, getValue(func, x) + addY);
                serie.Points.Add(data);
                //  }
            }
            serie.Color = OxyColors.Black;
            //serie.LineStyle = LineStyle.None;
            //serie.MarkerType = MarkerType.Circle;
            //serie.MarkerSize = 2;
            //serie.MarkerFill = OxyColors.Red;
            return serie;
        }
        public FunctionSeries addNormalPoints(List<Tuple<float, float>> list)
        {
            FunctionSeries serie = new FunctionSeries();
            foreach (Tuple<float, float> tp in list)
            {
                DataPoint data = new DataPoint(tp.Item1, tp.Item2);
                serie.Points.Add(data);
            }
            serie.Color = OxyColors.Black;
            serie.LineStyle = LineStyle.None;
            serie.MarkerType = MarkerType.Circle;
            serie.MarkerSize = 2;
            serie.MarkerFill = OxyColors.Blue;
            return serie;
        }
        public FunctionSeries addAnomalyPoints(List<Tuple<float, float>> list)
        {
            FunctionSeries serie = new FunctionSeries();
            foreach (Tuple<float, float> tp in list)
            {
                
                DataPoint data = new DataPoint(tp.Item1, tp.Item2);
                serie.Points.Add(data);
            }
            serie.Color = OxyColors.Black;
            serie.LineStyle = LineStyle.None;
            serie.MarkerType = MarkerType.Diamond;
            serie.MarkerSize = 2;
            serie.MarkerFill = OxyColors.Red;
            return serie;
        }

        public void LoadCSVS(string normal, string anomaly)
        {
            anomalies_Vm = new Anomalies_vm(normal, anomaly);
            anomalies_Vm.PropertyChanged += Update;
            Dispatcher.BeginInvoke(new Action(() => {
                DataContext = anomalies_Vm;
                cmb_items.ItemsSource = anomalies_Vm.Names;
            }));
        }

        private void Update(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("data") && sender == anomalies_Vm)
            {
                //cmb_items.ItemsSource = anomalies_Vm.Names;
                plot.Model = null;
                plotModel = new PlotModel();
                initModel();

                //add functions.
                PairData data = anomalies_Vm.dataPair;
                for (int i = 0; i < data.function.Count; i++)
                {
                    plotModel.Series.Add(addFunc(data.function[i], data.maxPoint, data.minPoint, (data.maxPoint- data.minPoint)/100, data.moveX, data.moveY));
                }
                plotModel.Series.Add(addNormalPoints(data.normal));
                plotModel.Series.Add(addAnomalyPoints(data.anomalies));
                plot.Model = plotModel;

            }
        }

        private void cmb_items_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmb_items.SelectedItem != null)
            {
                //System.Diagnostics.Trace.WriteLine(cmb_items.SelectedItem.ToString());
                anomalies_Vm.dataUpdate(cmb_items.SelectedItem.ToString());
            }
        }
    }
}
