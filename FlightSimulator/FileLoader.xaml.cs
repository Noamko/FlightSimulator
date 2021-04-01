using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for FileLoader.xaml
    /// </summary>
    public partial class FileLoader : Window
    {
        FileHandler fh;
        public FileLoader(FileHandler fh)
        {
            InitializeComponent();
            this.fh = fh;
        }
        public string[] Show_d()
        {
            this.Show();
            string[] arr = {fh.xmlPath, fh.csvPath, fh.fgPath};
            return arr;
        }

        private void checkFinish()
        {
            if(fh.csvPath != "" && fh.xmlPath != "" && fh.fgPath != "") {
                btn_submit.IsEnabled = true;
            }
        }
        private void btn_openXml_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            openFileDlg.DefaultExt = ".xml";
            openFileDlg.Filter = "XML Files (*.xml)|*.xml";
            Nullable<bool> result = openFileDlg.ShowDialog();
            if (result == true)
            {
                tb_xmlPath.Text = openFileDlg.FileName;
                fh.xmlPath = openFileDlg.FileName;

                string flightgearNeededPath = fh.xmlPath.Replace(@"data\Protocol\playback_small.xml", @"bin\fgfs.exe");
                if (this.fh.fgPath == "" && System.IO.File.Exists(flightgearNeededPath))
                {
                    this.fh.fgPath = flightgearNeededPath;
                    tb_exePath.Text = this.fh.fgPath;
                }
                checkFinish();
            }
        }

        private void btn_opebCSV_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            openFileDlg.DefaultExt = ".csv";
            openFileDlg.Filter = "CSV Files (*.csv)|*.csv";
            Nullable<bool> result = openFileDlg.ShowDialog();
            if (result == true)
            {
                tb_csvPath.Text = openFileDlg.FileName;
                fh.csvPath = openFileDlg.FileName;
                checkFinish();
            }
        }

        private void btn_opebEXE_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            openFileDlg.DefaultExt = ".exe";
            openFileDlg.Filter = "Executable Files (*.exe)|*.exe";
            Nullable<bool> result = openFileDlg.ShowDialog();
            if (result == true)
            {
                tb_exePath.Text = openFileDlg.FileName;
                fh.fgPath = openFileDlg.FileName;
                checkFinish();
            }
        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
