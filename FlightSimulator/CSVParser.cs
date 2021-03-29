using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSimulator
{
    interface CSVParser //a basic interface to get lines from a csv file
    {
        public void Parse();

        public string GetLine(int index);
    }
}
