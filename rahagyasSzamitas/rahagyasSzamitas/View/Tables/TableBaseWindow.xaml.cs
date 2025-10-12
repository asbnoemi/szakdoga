using rahagyasSzamitas.Modell;
using rahagyasSzamitas.Modell.Tablels;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for TableBaseWindow.xaml
    /// </summary>
    public partial class TableBaseWindow : Window
    {
        public TableBaseWindow()
        {
            InitializeComponent();
            
        }
        private string FileName { get; set; }
        public void FileNameLoded (string filename) 
        {
            FileName = filename;
        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBox_Initialized(object sender, EventArgs e)
        {
            
        }

     

        private void dataTable_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (FileName == "atlagos_feluleti_erdessgek_listas.csv")
            {
                DataArrange<DataTableITSize> Datal = new DataArrange<DataTableITSize>();
                var Dislist = new DataArrange<DataTableITSize>().GetAll(FileName);


                dataTable.ItemsSource = Dislist;

            }
            else if (FileName == "ITNum.csv")
            {
                DataArrange<DataTableITMultiplier> Datal = new DataArrange<DataTableITMultiplier>();
                var Dislist = new DataArrange<DataTableITMultiplier>().GetAll(FileName);
                dataTable.ItemsSource = Dislist;
            }

        }
    }
}
