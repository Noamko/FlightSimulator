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

        FileLoader_VM vm;

        public FileLoader(FileHandler fh)
        {
            InitializeComponent();
            vm = new FileLoader_VM(fh);
            DataContext = vm;

        }


        private void checkFinish()
        {
            if (vm.VM_csvPath != "" && vm.VM_xmlPath != "" && vm.VM_fgPath != "")
            {
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
                vm.VM_xmlPath = openFileDlg.FileName;
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
                vm.VM_csvPath = openFileDlg.FileName;
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
                vm.VM_fgPath = openFileDlg.FileName; ;
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
