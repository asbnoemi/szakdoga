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

using rahagyasSzamitas.Modell;
using System.IO;

namespace rahagyasSzamitas.View.MdulMainView
{
    /// <summary>
    /// Interaction logic for LoadSave.xaml
    /// </summary>
    public partial class LoadSave : Window
    {
        public LoadSave()
        {
            InitializeComponent();
        }

        private void CBopen_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> Files = new List<string>();
            Files = steps.Me.FindFromJason();
            foreach (string fullPath in Files)
            {
                string FileName = Path.GetFileName(fullPath);
                CBopen.Items.Add(FileName);
                CBopen.

            }
        }

        private void BTOpen_Click(object sender, RoutedEventArgs e)
        {
            string fullPath = CBopen.SelectedItem.ToString();

            steps.Me.LoadFromJason(CBopen.Text);
        }
    }
}
