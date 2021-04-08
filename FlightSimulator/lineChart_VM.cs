using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FlightSimulator
{
    class lineChart_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private lineChart_model model;
        private string name;

        DataPoint p1;
        DataPoint p2;
        public lineChart_VM()
        {
            name = "";
            model = new lineChart_model();
            model.PropertyChanged += delegate (Object sender, System.ComponentModel.PropertyChangedEventArgs e) {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public string[] VM_names
        {
            get { return model.names; }
        }


          public LinkedList<DataPoint> VM_list
        {
            get
            {
                if (!name.Equals(""))
                {
                    string corralted = model.getCorralatedName(name);
                    VM_CorralatedName = corralted;
                    VM_CorralatedList = model.getList(corralted);
                    NotifyPropertyChanged("VM_CorralatedList");
                    NotifyPropertyChanged("VM_CorralatedName");
             //       NotifyPropertyChanged("VM_list");
                    NotifyPropertyChanged("dataChanged");
                    ///
                    VM_points = model.getPointsOfCorralated(name);////////////////////
                    NotifyPropertyChanged("VM_points");////////////////////////
                    ///
                    return model.getList(name);
                }
                return null;
            }
        }


        public void updateList(string newName)
        {
            name = newName;
            /// updates the correlative graph
            string corralted = model.getCorralatedName(name);
            if (!corralted.Equals(""))
            {
                VM_CorralatedName = corralted;
                VM_CorralatedList = model.getList(corralted);
                NotifyPropertyChanged("VM_CorralatedList");
                NotifyPropertyChanged("VM_CorralatedName");
            }



            ///
            Tuple<DataPoint, DataPoint> twoPoints = model.linearRegOfCorrelative(newName);
            if (twoPoints != null)
            {
                List<DataPoint> lst = new List<DataPoint>();
                lst.Add(twoPoints.Item1);
                lst.Add(twoPoints.Item2);
                VM_lineRegList = lst;
                NotifyPropertyChanged("VM_lineRegList");
            }
            LinkedList<DataPoint> points = model.getPointsOfCorralated(newName);///////////////////////////////
            if(points != null)
            {
                VM_points = points;
                NotifyPropertyChanged("VM_points");
            }
            //////////////////////////////////////////////////////////////////////////



        }

        public LinkedList<DataPoint> VM_CorralatedList { get; set; }
        public string VM_CorralatedName { get; set; }


        public List<DataPoint> VM_lineRegList { get; set; }




        public LinkedList<DataPoint> VM_points { get; set; }
    }
}
