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

namespace DrugaAplikacja
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

        private void Tb2_TextChanged(object sender, TextChangedEventArgs e)
        {
            tb1.Text = tb2.Text;
            //if (tb1.Text.Length >= 10) tb1.Foreground = new SolidColorBrush(Colors.Red);
            //else tb1.Foreground = new SolidColorBrush(Colors.Green);
            tb1.Foreground =
                new SolidColorBrush(tb1.Text.Length >= 10 ? Colors.Red : Colors.Green);
            if (tb3 != null) tb3.Text = tb2.Text.Length.ToString();
        }
    }
}
