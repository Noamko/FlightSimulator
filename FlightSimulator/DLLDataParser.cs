using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSimulator
{
    class DLLDataParser
    {
        AnomalyDetector detector;
        Dictionary<string, PairData> pairs;
        FlightDataParser flight_parser;
        FlightController flightController;
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
        PairData getPair(string name)
        {
            return pairs[name];
        }
        void Parse()
        {
            for(int i = 0; i < detector.AnomalyCount(); i++)
            {
                PairData pairData = new PairData();
                pairData.name = detector.GetDiscription(i);
                pairData.function = detector.GetFunction(i);
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
                    pairData.normal.AddLast(new Tuple<float,float>(float.Parse(first_name_data[ii]), temp));
                    if(pairData.minPoint > temp) pairData.minPoint = temp;
                    if(pairData.maxPoint < temp) pairData.maxPoint = temp;
                }

                float first_name_point = float.Parse(flight_parser.GetDataFromLine(detector.GetTimeStep(i), first_name));
                float second_name_point = float.Parse(flight_parser.GetDataFromLine(detector.GetTimeStep(i), second_name));
                pairData.anomalies.AddLast(new Tuple<float, float>(first_name_point, second_name_point));
                pairs.Add(pairData.name,pairData);
            }
        }

    }
}
