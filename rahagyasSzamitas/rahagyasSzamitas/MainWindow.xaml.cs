using rahagyasSzamitas.Modell;
using rahagyasSzamitas.Modell.ModulMain;
using rahagyasSzamitas.Modell.Tablels;
using rahagyasSzamitas.View;
using rahagyasSzamitas.View.MdulMainView;
using rahagyasSzamitas.View.MdulMainView;
using rahagyasSzamitas.View.Tables;
using rahagyasSzamitas.ViewModell;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfMath.Controls;





namespace rahagyasSzamitas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CalculaiunsEdit calculationsEdit = new CalculaiunsEdit();
        LoadSave LoadSave;

        public MainWindow()
        {
            InitializeComponent();
            LoadSave = new LoadSave(this);
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {


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




        private void Calculate_BT_Click(object sender, RoutedEventArgs e)
        {
            ActualCalculate();

            void ActualCalculate()
            {
                string ITnum = "";
                double surfaceRoughness = 0;
                double size = 0;
                double diameter = 0;

                DataArrange<DataTableITSize> tableIT = new DataArrange<DataTableITSize>();
                switch (RBlength.IsChecked)
                {
                    case true:
                        if (texBoxSize.Text != "")
                        {
                            size = Convert.ToDouble(texBoxSize.Text);

                        }
                        else MessageBox.Show("Adja meg a méretet!");
                        break;
                    case false:
                        if (texBoxSize.Text != "" && RBdiameter.IsChecked == true) { diameter = Convert.ToDouble(texBoxSize.Text); }
                        else MessageBox.Show("Adja meg az átmérőt!");
                        break;
                    default:
                        MessageBox.Show("Válasszon az átmérö vagy a hosz megadása közül!");
                        break;
                }
                switch (RBchoose.IsChecked)
                {
                    case true:
                        ITnum = "";
                        if (IT5.IsChecked == true) { ITnum = "IT5"; }
                        else if (IT6.IsChecked == true) { ITnum = "IT6"; }
                        else if (IT7.IsChecked == true) { ITnum = "IT7"; }
                        else if (IT8.IsChecked == true) { ITnum = "IT8"; }
                        else if (IT9.IsChecked == true) { ITnum = "IT9"; }
                        else if (IT10.IsChecked == true) { ITnum = "IT10"; }
                        else if (IT11.IsChecked == true) { ITnum = "IT11"; }
                        else if (IT12.IsChecked == true) { ITnum = "IT12"; }
                        else if (IT13.IsChecked == true) { ITnum = "IT13"; }
                        else if (IT14.IsChecked == true) { ITnum = "IT14"; }
                        else if (IT15.IsChecked == true) { ITnum = "IT15"; }
                        else if (IT16.IsChecked == true) { ITnum = "IT16"; }
                        else { MessageBox.Show("Válasszon IT számot!"); break; }

                        double sizeForRoughness = size > 0 ? size : diameter;
                        surfaceRoughness = tableIT.GetAll("atlagos_feluleti_erdessgek_listas.csv").Find(x => (x.Itnum == ITnum)
                            && (x.sizeRangeMin <= sizeForRoughness)
                            && (x.sizeRangeMax >= sizeForRoughness)).size;

                        break;
                    case false:
                        if (RBwrite.IsChecked == true)
                        {
                            surfaceRoughness = Convert.ToDouble(texBoxRou.Text);
                            //vizsgáljuk h bene vane a táblázatban

                            ITnum = tableIT.GetAll("atlagos_feluleti_erdessgek_listas.csv").Find(x => ((x.size == surfaceRoughness)
                                && (x.sizeRangeMin <= size)
                                && (x.sizeRangeMax >= size))).Itnum;
                        }

                        else if (texBoxRou.Text == "") MessageBox.Show("Adja meg a felületi érdességet!");

                        break;
                    default:
                        MessageBox.Show("Válasszon módot!");
                        break;
                }
                try
                {
                    Calculation calc = new Calculation(size, surfaceRoughness, ITnum, diameter);
                    CalculationData result = calc.ThisCalculations();
                    Steps.Me.StepList.Add(result);
                    string content = $"legyártando Méret: {result.Size} mm\n" +
                        $"Felületi érdesség: {result.SurfaceRoughness} μm\n" +
                        $"IT szám: {result.ITnum}\n" +
                        $"türésegység:I: {result.I} mm\n" +
                        $"R: {result.R[1]} mm\n" +
                        $"T: {result.T} mm\n" +
                        $"O: {result.O} mm\n" +
                        $"Q: {result.R[2]}";
                    ResultBT.Content = content;
                    string contents = $$""""
                        i = 0{,}45 \cdot \sqrt[3]{D} + 0{,}001 \cdot D = 0{,}45 \cdot \sqrt[3]{{{result.Size}}} + 0{,}001 \cdot {{result.Size}}\\
                        i = {{result.I * 1000}},\mu m = {{result.I}},mm\\
                        {{result.ITnum}}\\
                        Q_a={{result.R[2]}}\\
                        T_a = q_a \cdot i = {{result.R[2]}} \cdot {{result.I}},mm = {{result.R[1]}},mm\\
                        [M + R_a] - Ta = \left[{{result.Size}},mm + 2 \cdot 4 \cdot {{result.R[2]}} \cdot {{result.I}},mm\right] = {{result.R[0]}} { - {{result.T}}}\\
                        [M + R_a] - Ta = \left[{{result.Size}},mm + 2 \cdot 4 \cdot {{result.R[2]}} \cdot {{result.I}},mm\right] = {{result.R[0]}} { - {{result.T}}}
                    """";

                    /*$$""""
                    i = 0{,}45 \cdot \sqrt[3]{D} + 0{,}001 \cdot D = 0{,}45 \cdot \sqrt[3]{{{result.Size}}} + 0{,}001 \cdot {{result.Size}}\\
                    i = {{result.I * 1000}}\,\mu m = {{result.I}}\,mm\\
                    {{result.ITnum}}\\
                    Q_a={{result.R[2]}}\\
                    T_a = q_a \cdot i = {{result.R[2]}} \cdot {{result.I}}\,mm = {{result.R[1]}}\,mm\\
                    [M + R_a] - T_a = \left[{{result.Size}}\,mm + 2 \cdot 4 \cdot {{result.R[2]}} \cdot {{result.I}}\,mm\right] = {{result.R[0]}} _{ - {{result.T}}}\\
                    [M + R_a] - T_a = \left[{{result.Size}}\,mm + 2 \cdot 4 \cdot {{result.R[2]}} \cdot {{result.I}}\,mm\right] = {{result.R[0]}} _{ - {{result.T}}}
                """";*/
                    FCvisual.Formula = contents;

                }
                catch (ArgumentException ae)
                {
                    MessageBox.Show(ae.Message);
                    return;
                }

            }

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            IT5.IsChecked = false;
            IT6.IsChecked = false;
            IT7.IsChecked = false;
            IT8.IsChecked = false;
            IT9.IsChecked = false;
            IT10.IsChecked = false;
            IT11.IsChecked = false;
            IT12.IsChecked = false;
            IT13.IsChecked = false;
            IT14.IsChecked = false;
            IT15.IsChecked = false;
            IT16.IsChecked = false;
            IT5.IsEnabled = false;
            IT6.IsEnabled = false;
            IT7.IsEnabled = false;
            IT8.IsEnabled = false;
            IT9.IsEnabled = false;
            IT10.IsEnabled = false;
            IT11.IsEnabled = false;
            IT12.IsEnabled = false;
            IT13.IsEnabled = false;
            IT14.IsEnabled = false;
            IT15.IsEnabled = false;
            IT16.IsEnabled = false;

            texBoxRou.Text = "";
            texBoxRou.IsEnabled = true;
        }


        private void texBoxSize_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (double.TryParse(texBoxSize.Text, out var result))
            {
                if (result < 0)
                {
                    MessageBox.Show("A méret nem lehet negatív!");
                    texBoxSize.Text = "";
                }
                if (result > 500) //ezt át kell irni ha változhat a táblazat
                {
                    MessageBox.Show("A méret nem lehet nagyobb 500!");
                    texBoxSize.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Csak számot adjon meg!");
                texBoxSize.Text = "";
            }
        }

        private void texBoxRou_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (double.TryParse(texBoxRou.Text, out var result))
            {
                if (result < 0)
                {
                    MessageBox.Show("A felületi érdesség nem lehet negatív!");
                    texBoxRou.Text = "";
                }
                if (result > 50) //ezt át kell irni ha változhat a táblazat
                {
                    MessageBox.Show("A felületi érdesség nem lehet nagyobb 50!");
                    texBoxRou.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Csak számot adjon meg!");
                texBoxRou.Text = "";
            }
        }

        private void RBlength_Checked(object sender, RoutedEventArgs e)
        {
            texBoxSize.Text = "";
            texBoxSize.IsEnabled = true;
        }

        private void RBdiameter_Checked(object sender, RoutedEventArgs e)
        {
            texBoxSize.Text = "";
            texBoxSize.IsEnabled = true;
        }

        private void BTnext_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("biztos menti ezt a lépést és ezezl számol továb?", "Megerősítés", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                return;
            }
            int length = (texBoxSize.Text.Length) - 1;
            //radiogombok álithatoságát oldd meg!!!!!
            texBoxSize.Text = Convert.ToString(Steps.Me.StepList[0].T);
            calculationsEdit.refres();

        }

        private void BTremuv_Click(object sender, RoutedEventArgs e)
        {
            int length = (texBoxSize.Text.Length) - 1;
            Steps.Me.StepList.RemoveAt(length);
        }

        private void BTStepsShow_Click(object sender, RoutedEventArgs e)
        {

            calculationsEdit.Show();

        }

        private void BTsaveOpen_Click(object sender, RoutedEventArgs e)
        {
            LoadSave.ShowDialog();
        }
        public void RefreLB()
        {
            CalculationData result = Steps.Me.StepList[Steps.Me.StepList.Count - 1];
            string content = $"legyártando Méret: {result.Size} mm\n" +
                    $"Felületi érdesség: {result.SurfaceRoughness} μm\n" +
                    $"IT szám: {result.ITnum}\n" +
                    $"türésegység:I: {result.I} mm\n" +
                    $"R: {result.R[1]} mm\n" +
                    $"T: {result.T} mm\n" +
                    $"O: {result.O} mm\n" +
                    $"Q: {result.R[2]}";
            ResultBT.Content = content;

        }



        private void TableOpen_Click(object sender, RoutedEventArgs e)
        {
            Tablechoice tablechoice = new Tablechoice();
            tablechoice.ShowDialog();
        }

        private void SowSave_Click(object sender, RoutedEventArgs e)
        {
            calculationsEdit.Show();

            calculationsEdit.TBfilename.Visibility = Visibility.Visible;
            calculationsEdit.TBfilename.IsEnabled = true;

        }


    }
}