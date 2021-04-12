using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSimulator
{
    class PairData
    {
        public string name { get; set; }
        public string function { get; set; }
        public LinkedList<Tuple<float,float>> anomalies { get; set; }
        public LinkedList<Tuple<float,float>> normal { get; set; }
        public List<string> anomaly_detection_times { get; set; }
        public float minPoint { get; set; }
        public float maxPoint { get; set; }
    }
}
