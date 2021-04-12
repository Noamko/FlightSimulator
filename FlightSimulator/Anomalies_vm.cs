using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FlightSimulator
{
    class Anomalies_vm : INotifyPropertyChanged
    {
        DLLDataParser parser;
        
        public event PropertyChangedEventHandler PropertyChanged;
        public Anomalies_vm(string normal, string anomaly)
        {
            parser = new DLLDataParser(normal, anomaly);
        }
    }
}
