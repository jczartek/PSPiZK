using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Colours
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            slR.Value = Properties.Settings.Default.R;
            slG.Value = Properties.Settings.Default.G;
            slB.Value = Properties.Settings.Default.B;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Color color = Color.FromRgb(
                (byte)slR.Value, 
                (byte)slG.Value, 
                (byte)slB.Value);
            Rectangle.Fill = new SolidColorBrush(color);
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            Properties.Settings.Default.R = (byte)slR.Value;
            Properties.Settings.Default.G = (byte)slG.Value;
            Properties.Settings.Default.B = (byte)slB.Value;
            Properties.Settings.Default.Save();
        }
    }
}
