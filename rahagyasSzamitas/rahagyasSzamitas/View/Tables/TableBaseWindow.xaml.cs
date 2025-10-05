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
        public TableBaseWindow(string FileName)
        {
            InitializeComponent();
            DataArrange<DataTableITSize> l = new DataArrange<DataTableITSize>();
          var Dislist   = new DataArrange<DataTableITSize>().GetAll("lis",FileName );
        
        
          dataTable.ItemsSource = Dislist;


        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBox_Initialized(object sender, EventArgs e)
        {
            
        }
    }
}
