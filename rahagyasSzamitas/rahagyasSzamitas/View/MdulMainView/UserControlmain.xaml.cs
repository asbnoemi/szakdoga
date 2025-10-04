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
using System.Windows.Navigation;
using System.Windows.Shapes;
using rahagyasSzamitas.Modell.Tablels;
using rahagyasSzamitas.View.Tables;
using rahagyasSzamitas.View;
using rahagyasSzamitas.Modell;


namespace rahagyasSzamitas
{
    /// <summary>
    /// Interaction logic for UserControlmain.xaml
    /// </summary>
    public partial class UserControlmain : UserControl
    {
        public UserControlmain()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            
            IT5.Visibility = Visibility.Visible;
            IT6.Visibility = Visibility.Visible;
            IT7.Visibility = Visibility.Visible;
            IT8.Visibility = Visibility.Visible;
            IT9.Visibility = Visibility.Visible;
            IT10.Visibility = Visibility.Visible;
            IT11.Visibility = Visibility.Visible;
            IT12.Visibility = Visibility.Visible;
            IT13.Visibility = Visibility.Visible;
            IT14.Visibility = Visibility.Visible;
            IT15.Visibility = Visibility.Visible;
            IT16.Visibility = Visibility.Visible;
            
            IT5.IsEnabled = true;
            IT6.IsEnabled = true;
            IT7.IsEnabled = true;
            IT8.IsEnabled = true;
            IT9.IsEnabled = true;
            IT10.IsEnabled = true;
            IT11.IsEnabled = true;
            IT12.IsEnabled = true;
            IT13.IsEnabled = true;
            IT14.IsEnabled = true;
            IT15.IsEnabled = true;
            IT16.IsEnabled = true;
            texBoxRou.IsEnabled = false;
            texBoxRou.Text = "felületi érdeség";

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ShowTable(object sender, RoutedEventArgs e)
        {
            TableBaseWindow tableBaseWindow = new TableBaseWindow();
            tableBaseWindow.Show();
        }

        private void szmBT_Click(object sender, RoutedEventArgs e)
        {
            TableBaseWindow tableBaseWindow = new TableBaseWindow();
        }

        

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            IT5.Visibility = Visibility.Hidden;
            IT6.Visibility = Visibility.Hidden;
            IT7.Visibility = Visibility.Hidden;
            IT8.Visibility = Visibility.Hidden;
            IT9.Visibility = Visibility.Hidden;
            IT10.Visibility = Visibility.Hidden;
            IT11.Visibility = Visibility.Hidden;
            IT12.Visibility = Visibility.Hidden;
            IT13.Visibility = Visibility.Hidden;
            IT14.Visibility = Visibility.Hidden;
            IT15.Visibility = Visibility.Hidden;
            IT16.Visibility = Visibility.Hidden;
            texBoxRou.Text = "";
            texBoxRou.IsEnabled = true; 
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            texBoxSize.Text = "";
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            texBoxSize.Text = "";
        }
    }
}
