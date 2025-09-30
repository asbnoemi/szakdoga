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
using rahagyasSzamitas.Modell.Tablels;

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
            TableData tableData = new TableData(0, 0, "", 0);
            var Dislist = tableData.TableDataLoad("atlagos_feluleti_erdessgek_listas.csv");
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
