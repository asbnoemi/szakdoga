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
            IT3.Visibility = Visibility.Visible;
            IT4.Visibility = Visibility.Visible;
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
            ITSamPng.Visibility = Visibility.Visible;
            IT3.IsEnabled = true;
            IT4.IsEnabled = true;
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
            

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
