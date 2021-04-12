using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        PlotModel plotmodel;
        Anomalies_vm anomalies_Vm;
        public AnomalyUC()
        {
            InitializeComponent();
            plotmodel =  initModel();
            plot.Model = plotmodel;
        }

        PlotModel initModel()
        {
            PlotModel model = new PlotModel { Title = "example" };
            model.LegendPosition = LegendPosition.RightBottom;
            model.LegendPlacement = LegendPlacement.Outside;
            model.LegendOrientation = LegendOrientation.Horizontal;
            var Yaxis = new OxyPlot.Axes.LinearAxis();
            var XAxis = new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Bottom };
            model.Axes.Add(Yaxis);
            model.Axes.Add(XAxis);
            //plot.Model = model;
            //model.TrackerChanged += Model_TrackerChanged;
            
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

        public FunctionSeries addFunc(string func, double max, double min, double interval)
        {
            double n = 100;
            FunctionSeries serie = new FunctionSeries();
            for (double x = min; x <= max; x += interval)
            {
                //    for (double y = min; y <= max; y += interval)
                //    {
                DataPoint data = new DataPoint(x, getValue(func, x));
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
                //var pointAnnotation = new PointAnnotation()
                //{
                //    X = Convert.ToDouble(tp.Item1),
                //    Y = Convert.ToDouble(tp.Item2),
                //    Text = String.Format("{0}-{1}", "asdasd", "asdsadq")
                //};
                
                DataPoint data = new DataPoint(tp.Item1, tp.Item2);
                serie.Points.Add(data);
                int i = 3;
                //plotmodel.Annotations.Add(pointAnnotation);
            }
            serie.TrackerFormatString = "hi";
            serie.Color = OxyColors.Black;
            serie.LineStyle = LineStyle.None;
            serie.MarkerType = MarkerType.Circle;
            serie.MarkerSize = 2;
            serie.MarkerFill = OxyColors.Red;
            //serie.TrackerFormatString += "hi";
            return serie;
        }

        public void LoadCSVS(string normal, string anomaly)
        {
            anomalies_Vm = new Anomalies_vm(normal, anomaly);
            anomalies_Vm.PropertyChanged += Update;
            DataContext = anomalies_Vm;
            cmb_items.ItemsSource = anomalies_Vm.Names;
        }

        private void Update(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("data") && sender == anomalies_Vm) 
            {
                //cmb_items.ItemsSource = anomalies_Vm.Names;
                plot.Model = null;
                
                PairData data = anomalies_Vm.datafunc;
                foreach (string function in data.function)
                {
                    plotmodel.Series.Add(addFunc(function, data.maxPoint, data.minPoint, data.interval));
                }
                plotmodel.Series.Add(addNormalPoints(data.normal));
                plotmodel.Series.Add(addAnomalyPoints(data.anomalies));
                plot.Model = plotmodel;

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
