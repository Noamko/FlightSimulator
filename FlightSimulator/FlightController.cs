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
        public FlightController()
        {
            fg_client = new FGClient();
        }

        public void SimulateFlight()
        {
            Trace.WriteLine("Connecting...");
            //new Thread(delegate ()
            //{
                bool running = true;
                while(running)
                {
                    if (fg_client.Connect("localhost", 5400))
                    {
                        Trace.WriteLine("Connected!");
                        string csv = @"C:\Users\noamk\Desktop\reg_flight.csv";
                        StreamReader csvFile = new StreamReader(csv);
                        string[] lines = File.ReadAllLines(csv);
                        for (int i = 0; i < lines.Length; i++)
                        {
                            fg_client.Send(lines[i] + "\n");
                            Trace.WriteLine(lines[i]);
                            Thread.Sleep(100);
                        }
                        fg_client.Close();
                        running = false;
                    }
                    else
                    {
                        Trace.WriteLine("Failed to Connect!.");
                    }
                }
            //});
        }
        public delegate void dataChanged();
    }
}
