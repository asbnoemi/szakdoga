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
using System.Windows.Shapes;
using XamlMath.Utils;

namespace rahagyasSzamitas.View
{
    /// <summary>
    /// Interaction logic for CalculaiunsEdit.xaml
    /// </summary>
    public partial class CalculaiunsEdit : Window
    {
        public CalculaiunsEdit()
        {
            InitializeComponent();
        }
        
        public void refres()
        {
            LBSteps.Items.Clear();
            foreach (CalculationData s in steps.Me.StepList)
            {
                string content = $"legyártando Méret: {s.Size} mm\n" +
                    $"Felületi érdesség: {s.SurfaceRoughness} μm\n" +
                    $"IT szám: {s.ITnum}\n" +
                    $"türésegység:I: {s.I} mm\n" +
                    $"R: {s.R[1]} mm\n" +
                    $"T: {s.T} mm\n" +
                    $"O: {s.O} mm\n" +
                    $"Q: {s.R[2]}"; 
                LBSteps.Items.Add(content);
            }
        }

        private void BTshave_Click(object sender, RoutedEventArgs e)
        {
            BTshave.Visibility = Visibility.Hidden;
            TBfilename.Visibility = Visibility.Visible;
            TBfilename.IsEnabled = true;
            BTok.Visibility = Visibility.Visible;
            BTok.IsEnabled = true;
            LBsave.Visibility = Visibility.Visible;
            TBfilename.IsEnabled = true;
            string filename = TBfilename.Text;
        }

        private void BTok_Click(object sender, RoutedEventArgs e)
        {
            if (TBfilename.Text == "")
            {
                MessageBox.Show("Kérem adjon meg egy fájlnevet!");
                return;
            }
            else
            {
                string FileName = TBfilename.Text;
                string FileNameJason = FileName+ ".json";
                steps.Me.SaveAsJason(FileNameJason);
                
                TBfilename.Visibility = Visibility.Hidden;
                TBfilename.IsEnabled = false;
                TBfilename.Text = "";
                BTok.Visibility = Visibility.Hidden;
                BTok.IsEnabled = false;
                LBsave.Visibility = Visibility.Hidden;
                TBfilename.IsEnabled = false;
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = FileName; 
                dlg.DefaultExt = ""; 
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    string saveFilename = dlg.FileName;
                   
                    string saveFileNamelatex = dlg.FileName + ".tex";
                    steps.Me.SaveLatex(saveFileNamelatex);
                    

                }MessageBox.Show("a file mentése sikeres latex file ba!");

            }
        }

        private void caledit_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();

        }

        private void caledit_Loaded(object sender, RoutedEventArgs e)
        {
            refres();
        }
    }
}
