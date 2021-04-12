using OxyPlot;
using OxyPlot.Series;
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
    /// Interaction logic for AnomalyUC.xaml
    /// </summary>
    public partial class AnomalyUC : UserControl
    {
        Anomalies_vm anomalies_Vm;
        public AnomalyUC()
        {
            InitializeComponent();
            plot.Model = initModel();
            plot.InvalidatePlot(true);
        }

        PlotModel initModel()
        {
            PlotModel model = new PlotModel { Title = "Anoamly Graph" };
            model.LegendPosition = LegendPosition.RightBottom;
            model.LegendPlacement = LegendPlacement.Outside;
            model.LegendOrientation = LegendOrientation.Horizontal;
            var Yaxis = new OxyPlot.Axes.LinearAxis();
            var XAxis = new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Bottom };
            model.Axes.Add(Yaxis);
            model.Axes.Add(XAxis);
            return model;
        }

        public double getValue(string func, double x)
        {
            string funcCopy = func;
            string result;
            funcCopy = funcCopy.Replace("x", x.ToString());
            funcCopy = funcCopy.Replace("X", x.ToString());
            NCalc.Expression e = new NCalc.Expression(funcCopy);
            result = e.Evaluate().ToString();
            return Double.Parse(result);
        }

        public FunctionSeries addFunc(string func, double max, double min, double interval)
        {
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
        public FunctionSeries addNormalPoints(LinkedList<Tuple<double, double>> list)
        {
            FunctionSeries serie = new FunctionSeries();
            foreach (Tuple<double, double> tp in list)
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
        public FunctionSeries addAnomalyPoints(LinkedList<Tuple<double, double>> list)
        {
            FunctionSeries serie = new FunctionSeries();
            foreach (Tuple<double, double> tp in list)
            {
                DataPoint data = new DataPoint(tp.Item1, tp.Item2);
                serie.Points.Add(data);
            }
            serie.Color = OxyColors.Black;
            serie.LineStyle = LineStyle.None;
            serie.MarkerType = MarkerType.Circle;
            serie.MarkerSize = 2;
            serie.MarkerFill = OxyColors.Red;
            return serie;
        }

        void LoadCSV(string normal, string anomaly)
        {
            anomalies_Vm = new Anomalies_vm(normal, anomaly);
        }
    }
}
