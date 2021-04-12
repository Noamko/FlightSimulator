using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace FlightSimulator
{
    class DLLDataParser : INotifyPropertyChanged
    {
        AnomalyDetector detector;
        Dictionary<string, PairData> pairs;
        FlightDataParser flight_parser;
        FlightController flightController;

        public event PropertyChangedEventHandler PropertyChanged;

        public DLLDataParser(string normal, string anomaly)
        {
            pairs = new Dictionary<string, PairData>();
            detector = new AnomalyDetector();
            flightController = FlightController.GetInstance;
            flight_parser = flightController.getParser;

            //learn and detect
            detector.LearnNormal(string.Join(",",flightController.Names), normal);
            detector.Detect(string.Join(",", flightController.Names), anomaly);

            //parse data
            Parse();





        }
        public PairData getPair(string name)
        {
            return pairs[name];
        }
        void Parse()
        {
            for(int i = 0; i < detector.AnomalyCount(); i++)
            {
                PairData pairData = new PairData();
                pairData.name = detector.GetDiscription(i);
                //pairData.function = detector.GetFunction(i);
                int minMaxFlag = parseFuncs(pairData, detector.GetFunction(i));
                pairData.anomaly_detection_times.Add((detector.GetTimeStep(i).ToString()));

                string first_name = pairData.name.Split(',')[0];
                string second_name = pairData.name.Split(',')[1];
                string[] first_name_data = flight_parser.GetDataByName(first_name);
                string[] second_name_data = flight_parser.GetDataByName(second_name);

                pairData.minPoint = float.Parse(second_name_data[0]);
                pairData.maxPoint = pairData.minPoint;
                for (int ii = 0; ii < first_name_data.Length; ii++)
                {
                    float temp = float.Parse(second_name_data[ii]);
                    pairData.normal.Add(new Tuple<float,float>(float.Parse(first_name_data[ii]), temp));
                    if(pairData.minPoint > temp) pairData.minPoint = temp;
                    if(pairData.maxPoint < temp) pairData.maxPoint = temp;
                }
                if(minMaxFlag == 0)
                {
                    //need to implement the parsing of min and max from the dll information.
                }
                float first_name_point = float.Parse(flight_parser.GetDataFromLine(detector.GetTimeStep(i), first_name));
                float second_name_point = float.Parse(flight_parser.GetDataFromLine(detector.GetTimeStep(i), second_name));
                pairData.anomalies.Add(new Tuple<float, float>(first_name_point, second_name_point));
                if (!pairs.ContainsKey(pairData.name))
                    pairs.Add(pairData.name, pairData);
                else
                {//need to make more efficient
                    pairs[pairData.name].anomaly_detection_times.AddRange(pairData.anomaly_detection_times);
                    pairs[pairData.name].anomalies.AddRange(pairData.anomalies);
           //         pairs[pairData.name].normal.AddRange(pairData.normal);
                }
            }

        }

        //the function makes a list of the function and returns 1 if the min and max points should be global and 0 otherwise.
        private int parseFuncs(PairData data ,string funcs)
        {
            string[] funcsArr = funcs.Split("|");
            foreach (string function in funcsArr)
            {
                if (function[function.Length - 1] != '$')
                    data.function.Add(function);
            }
            if (funcsArr[funcsArr.Length - 1].Equals("0$"))
                return 1;
            return 0;
        } 

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public string[] getNamesPairs()
        {
            string[] names = new string[pairs.Count];
            int i = 0;
            foreach (string key in pairs.Keys)
            {
                names[i] = key;
                i++;
            }
            return names;
        }

    }
}
