using Microsoft.Win32;
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

namespace ImagePrinter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog openFileDialog = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog == null)
            {
                openFileDialog = new OpenFileDialog();
            }

            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileName = new Uri(openFileDialog.FileName);
                imageToPrint.Source = new BitmapImage(fileName);
            }
        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            if (imageToPrint.Source == null)
                return;

            Printing.PrintImage(imageToPrint);
        }
    }
}
