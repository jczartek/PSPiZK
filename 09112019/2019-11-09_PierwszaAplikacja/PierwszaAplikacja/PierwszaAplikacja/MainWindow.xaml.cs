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

namespace PierwszaAplikacja
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

        private void Przycisk_Click(object sender, RoutedEventArgs e)
        {
            przycisk.Width = 300;
            przycisk.Foreground = new SolidColorBrush(Colors.Green);
            przycisk.Background = new SolidColorBrush(Colors.Yellow);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            pasekPostępu.Value = e.NewValue;            
            pasekPostępu.Foreground = new SolidColorBrush(
                Color.FromRgb((byte)e.NewValue, (byte)(255 - e.NewValue), 0)
                );
        }
    }
}
