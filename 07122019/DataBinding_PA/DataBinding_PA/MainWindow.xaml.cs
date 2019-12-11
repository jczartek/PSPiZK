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

namespace DataBinding_PA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class DaneOkna
        {
            public string labelka { get; set; }
            public string tekst { set; get; }
        }

        int a = 0;

        DaneOkna dane = new DaneOkna();

        public MainWindow()
        {
            InitializeComponent();

            
            dane.labelka = "Hello world!";

            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            this.DataContext = dane;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            a++;
            dane.labelka = a.ToString();
            DataContext = dane;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            label.Content = dane.tekst;
        }
    }
}
