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

namespace ColorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Color RectangleColor
        {
            get { return (rectangle.Fill as SolidColorBrush).Color; }
            set { (rectangle.Fill as SolidColorBrush).Color = value; }
        }

        private bool _afterInitialized = false;
        private bool AfterInitialized
        {
            get { return _afterInitialized; }
            set { _afterInitialized = value; }
        }
        public MainWindow()
        {
            InitializeComponent();
            Settings.ReadWindowState(this);
            Color color = Settings.ReadColorSettings();

            silderR.Value = color.R;
            silderG.Value = color.G;
            silderB.Value = color.B;
            rectangle.Fill = new SolidColorBrush(color);
            AfterInitialized = true;
        }

        private void SilderR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (AfterInitialized == false) return;

            Color color = Color.FromRgb(
                (byte)silderR.Value,
                (byte)silderG.Value,
                (byte)silderB.Value);

            RectangleColor = color;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Settings.SaveColorSettings(RectangleColor);
            Settings.SaveWindowState(this);
        }
    }
}
