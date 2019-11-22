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

namespace RownaniaKwadratowe2019
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void B1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double a = double.Parse(tb1.Text);
                double b = double.Parse(tb2.Text);
                double c = double.Parse(tb3.Text);
                RównanieKwadratowe r = new RównanieKwadratowe();
                RównanieKwadratowe.Wyniki wyniki = r.Oblicz(a, b, c);
                block1_run.Text = wyniki.X1.ToString();
                block2_run.Text = wyniki.X2.ToString();
            }
            catch(Exception exc)
            {
                MessageBox.Show(
                    "Wystąpił błąd: " + exc.Message,
                    "Błąd",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }            
        }
    }
}
