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

        public delegate void dataChangedEventHandler(object sender, FlightControllerEventArgs e);
        public event dataChangedEventHandler dataUpdated;
        FlightDataParser parser;

        public FlightController()
        {
            fg_client = new FGClient();
            running = false;

            string csv = @"C:\Users\noamk\Desktop\reg_flight.csv"; //should get this from FileHandler
            StreamReader csvFile = new StreamReader(csv);
            parser = new FlightDataParser(csv);
            Trace.WriteLine(parser.GetDataFromLine(400, "aileron"));

            
        }

        private void Notify(int line)
        {
            FlightControllerEventArgs e_args = new FlightControllerEventArgs(parser.Parse(line));
            dataUpdated(this, e_args);
        }

        private void FlightController_dataChanged(object sender, EventArgs e)
        {
        }


        // should be here?
        public void StartFlightGear()
        {
            //if (fileHandler.fgPath == null)
            //    throw new NullReferenceException("FlightGear Path isn't initialized");
            //System.Diagnostics.Process.Start(fileHandler.fgPath, "--launcher");
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
                        string csv = @"C:\Users\noamk\Desktop\reg_flight.csv"; //should get this from FileHandler
                        StreamReader csvFile = new StreamReader(csv);
                        string[] lines = File.ReadAllLines(csv);
                        for (int i = firstLine; i < lines.Length; i++)
                        {
                            Notify(i);

                            //should be here?
                            fg_client.Send(lines[i] + "\n");
                            Trace.WriteLine(lines[i]);
                            Thread.Sleep(100);
                            //lastLine = i; // todo move this to media player ->change to mediaplayer.setCurrentLine(i);

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
