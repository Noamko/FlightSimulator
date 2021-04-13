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
            detector.UnloadDlls();
        }
        public PairData getPair(string name)
        {
            return pairs[name];
        }
        void Parse()
        {
            for (int i = 0; i < detector.AnomalyCount(); i++)
            {
                PairData pairData = new PairData();
                pairData.name = detector.GetDiscription(i);

                string first_name = pairData.name.Split(',')[0];
                string second_name = pairData.name.Split(',')[1];
                string[] first_name_data = flight_parser.GetDataByName(first_name);
                string[] second_name_data = flight_parser.GetDataByName(second_name);

                //f(x)#g(x)...|0,x
                //parse functions
                string function = detector.GetFunction(i);
                string[] function_data = function.Split('|');
                string[] functions = function_data[0].Split('#');

                pairData.function.AddRange(functions);

                string[] functions_info = function_data[1].Split(",");

                if (int.Parse(functions_info[0].ToString()) == 2)
                {
                    pairData.minPoint = float.Parse(functions_info[1]);
                    pairData.maxPoint = float.Parse(functions_info[2]);
                }

                else {
                    pairData.minPoint = float.Parse(second_name_data[0]);
                    pairData.maxPoint = pairData.minPoint;
                    for (int ii = 0; ii < first_name_data.Length; ii++)
                    {
                        float temp = float.Parse(second_name_data[ii]);
                        pairData.normal.Add(new Tuple<float, float>(float.Parse(first_name_data[ii]), temp));
                        if (pairData.minPoint > temp) pairData.minPoint = temp;
                        if (pairData.maxPoint < temp) pairData.maxPoint = temp;
                    }
                }
                if (pairs.ContainsKey(pairData.name))
                {
                    pairs[pairData.name].anomaly_detection_times.Add(detector.GetTimeStep(i).ToString());
                }
                else
                {
                    pairData.anomaly_detection_times.Add(detector.GetTimeStep(i).ToString());
                    pairs.Add(pairData.name, pairData);
                }
            }

            foreach(PairData P in pairs.Values)
            {
                string[] data_1 = flight_parser.GetDataByName(P.name.Split(',')[0]);
                string[] data_2 = flight_parser.GetDataByName(P.name.Split(',')[1]);
                for (int i = 0; i < detector.AnomalyCount(); i++)
                {
                    float f1 = float.Parse(flight_parser.GetDataFromLine(detector.GetTimeStep(i), P.name.Split(',')[0]));
                    float f2 = float.Parse(flight_parser.GetDataFromLine(detector.GetTimeStep(i), P.name.Split(',')[1]));
                    P.anomalies.Add(new Tuple<float, float>(f1, f2));
                    P.anomaly_detection_times.Add(detector.GetTimeStep(i).ToString());
                }
                for(int i = 0; i < data_1.Length; i++)
                {
                    if (!P.anomaly_detection_times.Contains(i.ToString()))
                    {
                        float f1 = float.Parse(data_1[i]);
                        float f2 = float.Parse(data_2[i]);
                        P.normal.Add(new Tuple<float, float>(f1, f2));
                    }
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
