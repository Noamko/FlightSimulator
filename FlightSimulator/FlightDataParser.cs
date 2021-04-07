using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FlightSimulator
{
    class FlightDataParser : CSVParser //get lines from a csv file parse them as flight data.
    {
        string csv_file;
        string[] lines;
        Dictionary<int, string> data_headers;
        
        //TODO: are this strings should be stored globaly?
        public FlightDataParser(string csv_file)
        { 
            this.csv_file = csv_file;
            lines = File.ReadAllLines(this.csv_file);
            data_headers = new Dictionary<int, string>();
            data_headers.Add(0,Configuration.AILERON);
            data_headers.Add(1,Configuration.ELEVATOR);
            data_headers.Add(2,Configuration.RUDDER);
            data_headers.Add(3,Configuration.FLAPS);
            data_headers.Add(4,Configuration.SLATS);
            data_headers.Add(5,Configuration.SPEED_BRAKE);
            data_headers.Add(6,Configuration.ENGINE1_THROTTLE);
            data_headers.Add(7,Configuration.ENGINE2_THROTTLE);
            data_headers.Add(8,Configuration.ENGINE1_PUMP);
            data_headers.Add(9,Configuration.ENGINE2_PUMP);
            data_headers.Add(10,Configuration.ELECTRIC1_PUMP);
            data_headers.Add(11,Configuration.ELECTRIC2_PUMP);
            data_headers.Add(12,Configuration.EXTERNAL_POWER);
            data_headers.Add(13,Configuration.APU_GENERATOR);
            data_headers.Add(14,Configuration.LATITUDE_DEG);
            data_headers.Add(15,Configuration.LONGTITUDE_DEG);
            data_headers.Add(16,Configuration.ALTITUDE_DEG);
            data_headers.Add(17,Configuration.ROLL_DEG);
            data_headers.Add(18,Configuration.PITCH_DEG);
            data_headers.Add(19,Configuration.HEADING_DEG);
            data_headers.Add(20,Configuration.SIDE_SLIP_DEG);
            data_headers.Add(21,Configuration.AIRSPEED_KT);
            data_headers.Add(22,Configuration.GLIDESLOP);
            data_headers.Add(23,Configuration.AIRSPEED_INDICATOR_INDICATED_SPEED_KT);
            data_headers.Add(24,Configuration.ALTIMETER_INDICATED_ALTITUDE_FT);
            data_headers.Add(25,Configuration.ALTIMETER_PRESSURE_ALT_FT);
            data_headers.Add(26,Configuration.ATTITUDE_INDICATOR_INDICATED_PITCH_DEG);
            data_headers.Add(27,Configuration.ATTITUDE_INDICATOR_INDICATED_ROLL_DEG);
            data_headers.Add(28,Configuration.ATTITUDE_INDICATOR_INTERNAL_PITCH_DEG);
            data_headers.Add(29,Configuration.ATTITUDE_INDICATOR_INTERNAL_ROLL_DEG);
            data_headers.Add(30,Configuration.ENCODER_INDICATED_ALTITUDE_FT);
            data_headers.Add(31,Configuration.ENCODER_PRESSURE_ALT_FT);
            data_headers.Add(32,Configuration.GPS_INDICATED_ALTITUDE_FT);
            data_headers.Add(33,Configuration.GPS_INDICATED_GROUNDSPEED_KT);
            data_headers.Add(34,Configuration.GPS_INDICATED_VERTICAL_SPEED);
            data_headers.Add(35,Configuration.INDICATED_HEADING_DEG);
            data_headers.Add(36,Configuration.MAGNETIC_COMPASS_INDICATED_HEADING_DEG);
            data_headers.Add(37,Configuration.SLIP_SKID_BALL_INDICATED_SLIP_SKID);
            data_headers.Add(38,Configuration.TURN_INDICATOR_INDICATED_TURNRATE);
            data_headers.Add(39,Configuration.VERTIAL_SPEED_INDICATOR_INDICATED_SPEED_FDM);
            data_headers.Add(40,Configuration.ENGINE_RPM);
        }

        public Dictionary<string,string> Parse(int line)
        {
            Dictionary<string, string>  data_values = new Dictionary<string, string>(); //actual values
            for(int i = 0; i < data_headers.Count; i++)
            {
                string[] line_data = GetLine(line).Split(',');
                data_values.Add(data_headers[i], line_data[i]);
            }

            return data_values;
        }
        public string GetDataFromLine(int line,string name)
        {
            return Parse(line)[name];
        }
        public string GetLine(int index)
        {
            return lines[index];
        }

        public int GetNumberOfLines()
        {
            return lines.Length;
        }
    }
}
