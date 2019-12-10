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
using System.Windows.Threading;

namespace Stoper_PA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer;
        private double _czas;

        public MainWindow()
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(33);
            _timer.Tick += timerTickFunction;
            _czas = 0.0;
        }

        private void timerTickFunction(object sender, EventArgs e)
        {
            _czas += 0.033;
            label.Content = _czas.ToString("");
        }

        private void Start_button_Click(object sender, RoutedEventArgs e)
        {
            _timer.Start();
        }

        private void Stop_button_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
        }

        private void Reset_button_Click(object sender, RoutedEventArgs e)
        {
            _czas = 0.0;
            label.Content = _czas.ToString();
        }
    }
}
