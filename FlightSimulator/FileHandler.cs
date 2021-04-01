using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSimulator
{
    public class FileHandler
    {
        public string xmlPath { get; set;}
        public string fgPath { get; set; }
        public string csvPath { get; set; }

        public FileHandler()
        {
            xmlPath = "";
            fgPath = "";
            csvPath = "";
        }
    }
}
