using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

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
