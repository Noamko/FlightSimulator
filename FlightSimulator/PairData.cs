using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSimulator
{
    class PairData
    {
        public PairData()
        {
            anomalies = new List<Tuple<float, float>>();
            normal = new List<Tuple<float, float>>();
            anomaly_detection_times = new List<string>();
            function = new List<string>();
            interval = 0.1f;// need to decide what the best
        }
        public string name { get; set; }
        public List<string> function { get; set; } //need list of min max for every function??
        public List<Tuple<float,float>> anomalies { get; set; }
        public List<Tuple<float,float>> normal { get; set; }
        public List<string> anomaly_detection_times { get; set; }
        public float minPoint { get; set; }
        public float maxPoint { get; set; }

        public float interval { get; private set; }
    }
}
