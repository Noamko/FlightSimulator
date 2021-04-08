using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;

namespace FlightSimulator
{
    //Should have al
    class FlightController
    {
        FGClient fg_client;

        public string csv_file { get; set; }

        static FlightController instance = null;

        public delegate void dataChangedEventHandler(object sender, FlightControllerEventArgs e);
        public event dataChangedEventHandler dataUpdated;
        FlightDataParser parser;

        mediaController media;
        DataCalculations dc;

        private FlightController()
        {
            fg_client = new FGClient();
            media = mediaController.GetInstance;
        }

        public static FlightController GetInstance
        {
            get
            {
                if(instance == null)
                {
                    instance = new FlightController();
                }
                return instance;
            }
        }
        public void loadCSV(string csv)
        {
            this.csv_file = csv;
            
            parser = new FlightDataParser(csv);
            media.numberOfLines = parser.GetNumberOfLines();
            media.PropertyChanged += play;
            dc = new DataCalculations(parser);
            TestMethod();
        }

        private void play(object sender, PropertyChangedEventArgs e)
        {
            if (sender == media && e.PropertyName.Equals("play"))
                this.SimulateFlight();
        }

        public int getNumberOfLines()
        {
            if(parser == null)
            {
                return 0;
            }
            return parser.GetNumberOfLines();
        }
        private void Notify(int line)
        {
            FlightControllerEventArgs e_args = new FlightControllerEventArgs(parser.Parse(line));
            if (dataUpdated != null)
            {
                dataUpdated(this, e_args);
            }
        }

        private void FlightController_dataChanged(object sender, EventArgs e)
        {

        }

        
        public void SimulateFlight()
        {
            new Thread(delegate ()
            {
                    if (fg_client.Connect("localhost", 5400))
                    {
                        string[] lines = File.ReadAllLines(csv_file);
                        while (media.isRunning)
                        {
                        int i = media.firstLine;
                            Notify(i);
                            fg_client.Send(lines[i] + "\n");
                            Thread.Sleep(media.simulationSpeed);
                            media.firstLine++;

                        }
                        fg_client.Close();
                    }
                    else
                    {
                        Trace.WriteLine("Error");
                    }
            }).Start();
        }


        public DataCalculations getDataCalculations { get { return dc; } }

        public FlightDataParser getParser { get { return this.parser; } }



        public void TestMethod()
        {
        //    //      string[] data = parser.GetDataByName("rudder");
        //    //        foreach (string d in data )
        //    //              System.Diagnostics.Trace.WriteLine(float.Parse(d));


        //   double data = dc.pearsonOfTwoVals("aileron", "airspeed_indicator_indicated_speed_kt");/////////////////////

        //    System.Diagnostics.Trace.WriteLine(data);
        //    System.Diagnostics.Trace.WriteLine(dc.pearsonOfTwoVals("airspeed_indicator_indicated_speed_kt","aileron"));////////
        //    System.Diagnostics.Trace.WriteLine(dc.pearsonOfTwoVals("aileron", "slip-skid-ball_indicated-slip-skid"));///////////////////

        //    System.Diagnostics.Trace.WriteLine(dc.pearsonOfTwoVals("slip-skid-ball_indicated-slip-skid", "airspeed_indicator_indicated_speed_kt"));
        //    System.Diagnostics.Trace.WriteLine(dc.pearsonOfTwoVals("airspeed_indicator_indicated_speed_kt", "slip-skid-ball_indicated-slip-skid"));
        //    Trace.WriteLine(dc.pearsonOfTwoVals("slip-skid-ball_indicated-slip-skid", "aileron"));//////////
        //    System.Diagnostics.Trace.WriteLine("MAX: "+dc.getMaxPearson("aileron"));
        }

    }
}
