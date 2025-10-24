using Microsoft.VisualBasic;
using rahagyasSzamitas.Modell.ModulMain;
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


namespace rahagyasSzamitas.ViewModell
{
    /// <summary>
    /// Interaction logic for CalculationsEdit.xaml
    /// </summary>
    public partial class CalculationsEdit : Window
    {
        public CalculationsEdit()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            refres();
        }
        public void refres()
        {
            foreach (CalculationData s in steps.Me.StepList) 
            {
                string content = $"legyártando Méret: {s.size} mm\n" +
                    $"Felületi érdesség: {s.surfaceRoughness} μm\n" +
                    $"IT szám: {s.ITnum}\n" +
                    $"türésegység:i: {s.i} mm\n" +
                    $"R: {s.R[1]} mm\n" +
                    $"T: {s.T} mm\n" +
                    $"O: {s.O} mm";
                LBSteps.Items.Add(content);
            }}

        private void BTshave_Click(object sender, RoutedEventArgs e)
        {
            TBfilename.Visibility= Visibility.Visible;
            TBfilename.IsEnabled= true;
            BTok.Visibility= Visibility.Visible;
            BTok.IsEnabled= true;
            LBsave.Visibility= Visibility.Visible;
            TBfilename.IsEnabled= true;
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
                steps.Me.SaveAsJason(TBfilename.Text);
                MessageBox.Show("Sikeres mentés!");
                TBfilename.Visibility= Visibility.Hidden;
                TBfilename.IsEnabled= false;
                TBfilename.Text= "";
                BTok.Visibility= Visibility.Hidden;
                BTok.IsEnabled= false;
                LBsave.Visibility= Visibility.Hidden;
                TBfilename.IsEnabled= false;

            }
        }
    }
}
