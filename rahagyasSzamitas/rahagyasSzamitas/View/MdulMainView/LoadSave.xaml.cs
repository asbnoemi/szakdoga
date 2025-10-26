using rahagyasSzamitas.Modell.ModulMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using rahagyasSzamitas.View;
using rahagyasSzamitas.Modell;
using System.IO;

namespace rahagyasSzamitas.View.MdulMainView
{
    /// <summary>
    /// Interaction logic for LoadSave.xaml
    /// </summary>
    public partial class LoadSave : Window
    {
        private MainWindow mainWindow;
        public LoadSave(MainWindow MainWindow)
        {
            InitializeComponent();
            mainWindow = MainWindow;
        }
        
        List<string> Files = new List<string>();

        private void CBopen_Loaded(object sender, RoutedEventArgs e)
        {
            
            Files = steps.Me.FindFromJason();
            foreach (string fullPath in Files)
            {
                string FileName = Path.GetFileName(fullPath);
                CBopen.Items.Add(FileName);
                

            }
        }

        private void BTOpen_Click(object sender, RoutedEventArgs e)
        {
            string fullPath =Files[CBopen.SelectedIndex];

            steps.Me.LoadFromJason(fullPath);
            this.Close();
            mainWindow.RefreLB();

        }

        private void LodSaveWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
