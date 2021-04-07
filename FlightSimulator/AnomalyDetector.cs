using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace FlightSimulator
{

    class AnomalyDetector
    {
        const string dll_path = @"C:\Users\noamk\source\repos\AnomalyDetectorLib\x64\Debug\AnomalyDetectorLib.dll";

        [DllImport(dll_path, EntryPoint = "learn")]
        static extern void learn(IntPtr detector, IntPtr names, int size, IntPtr sw);

        [DllImport(dll_path, EntryPoint = "detect")]
        static extern IntPtr detect(IntPtr detector, IntPtr names, int size, IntPtr sw);

        [DllImport(dll_path, EntryPoint = "createSimpleAnomalyDetectorInstance")]
        static extern IntPtr createSimpleAnomalyDetectorInstance();

        [DllImport(dll_path, EntryPoint = "dispose")]
        static extern int dispose(IntPtr v);

        [DllImport(dll_path, EntryPoint = "getTimeStep")]
        static extern int getTimeStep(IntPtr v, int index);

        [DllImport(dll_path, EntryPoint = "getDesciption")]
        static extern IntPtr getDesciption(IntPtr v, int index);

        [DllImport(dll_path, EntryPoint = "CHECK")]
        static extern int CHECK();

        [DllImport(dll_path, EntryPoint = "createString")]
        static extern IntPtr createString(int len);

        [DllImport(dll_path, EntryPoint = "addCharToString")]
        static extern void addCharToString(IntPtr sw, char c);

        [DllImport(dll_path, EntryPoint = "getChar")]
        static extern char getChar(IntPtr sw, int index);

        [DllImport(dll_path, EntryPoint = "len")]
        static extern int len(IntPtr sw);


        IntPtr detector;
        IntPtr AnomalyReportVector;
        public AnomalyDetector()
        {
            this.detector = createSimpleAnomalyDetectorInstance();
        }

        public IntPtr _String(string s)
        {
            IntPtr STR = createString(s.Length);
            for (int i= 0; i < s.Length; i++)
            {
                addCharToString(STR, s[i]);
            }
            return STR;
        }
        public void LearnNormal(string names, string filename)
        {
            IntPtr f = _String(filename);
            IntPtr _names = _String(names);
            learn(detector,_names, names.Length, f);
        }

        public void Detect(string names, string filename)
        {
            IntPtr f = _String(filename);
            IntPtr _names = _String(names);
            AnomalyReportVector = detect(this.detector, _names, names.Length, f);
        }

        public string GetDiscription(int index)
        {
            IntPtr sw = getDesciption(AnomalyReportVector, index);
            string s = "";
            for(int i = 0; i < len(sw); i++)
            {
                s += getChar(sw, i);
            }
            return s;
        }

        public int GetTimeStep(int index)
        {
            return getTimeStep(AnomalyReportVector, index);
        }

        ~AnomalyDetector()
        {
            dispose(detector);
        }
    }
}
