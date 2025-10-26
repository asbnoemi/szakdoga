using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace rahagyasSzamitas.View.Tables
{
    /// <summary>
    /// Interaction logic for Tablechoice.xaml
    /// </summary>
    public partial class Tablechoice : Window
    {
        public Tablechoice()
        {
            InitializeComponent();
        }

        private void OpenBT_Click(object sender, RoutedEventArgs e)
        {
            switch (TablesComB.Text) 
            { 
                case "Átlagos felületi érdességek":
                        TableBaseWindow table1 = new TableBaseWindow();
                     table1.FileNameLoded("atlagos_feluleti_erdessgek_listas.csv");

                    table1.Show();
                        this.Close();
                        break;
                case "IT méretek":
                    TableBaseWindow table2 = new TableBaseWindow();
                   table2.FileNameLoded("ITNum.csv");
                    table2.Show();
                        this.Close();
                        break;
                default:
                    MessageBox.Show("Válasszon táblázatot!");
                    break;
            }
        }

        private void TablesComB_Loaded(object sender, RoutedEventArgs e)
        {
            string [] tables = new string[] { "Átlagos felületi érdességek", "IT méretek" };
            TablesComB.ItemsSource = tables;
        }

      

        private void OpenTEdit_Click(object sender, RoutedEventArgs e)
        {
            using Process myProcess = new Process();
                myProcess.StartInfo.FileName = "C:\\Program Files\\Microsoft Office\\root\\Office16\\EXCEL.EXE";
            switch (TablesComB.Text)
            {
                
                case "Átlagos felületi érdességek":
                    
                    myProcess.StartInfo.Arguments = "atlagos_feluleti_erdessgek_listas.csv";
                    myProcess.Start();
                    break;
                case "IT méretek":
                    myProcess.StartInfo.Arguments = "ITNum.csv";
                    myProcess.Start();
                    break;
                default:
                    MessageBox.Show("Válasszon táblázatot!");
                    break;
            }
            
            
            ;
        }
    }
}
