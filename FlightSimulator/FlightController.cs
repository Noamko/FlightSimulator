using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace FlightSimulator
{
    //Should have al
    class FlightController
    {
        FGClient fg_client;
        bool running;
        public int simulationSpeed { get; set; }
        public string csv_file { get; set; }
        public int startingLine { get; set; }
        static FlightController instance = null;

        public delegate void dataChangedEventHandler(object sender, FlightControllerEventArgs e);
        public event dataChangedEventHandler dataUpdated;
        FlightDataParser parser;

        private FlightController()
        {
            fg_client = new FGClient();
            running = true;
            simulationSpeed = 100;
            startingLine = 0;
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
            dataUpdated(this, e_args);
        }

        private void FlightController_dataChanged(object sender, EventArgs e)
        {

        }

        public void StopSimulation()
        {
            this.running = false;
        }
        
        public void SimulateFlight(int firstLine)
        {
            new Thread(delegate ()
            {
                while(running)
                {
                    if (fg_client.Connect("localhost", 5400))
                    {
                        string[] lines = File.ReadAllLines(csv_file);
                        for (int i = firstLine; i < lines.Length; i++)
                        {
                            Notify(i);

                            //should be here?
                            fg_client.Send(lines[i] + "\n");
                            Thread.Sleep(simulationSpeed);
                            this.startingLine = i;

                        }
                        fg_client.Close();
                        running = false;
                    }
                    else
                    {
                        Trace.WriteLine("Error");
                    }
                }
            }).Start();
        }
    }
}
