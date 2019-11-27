using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace NotatnikWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void miZakończ_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult wynik = MessageBox.Show("Czy na pewno chcesz zamknąć notatnik?", Title, MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch(wynik)
            {
                case MessageBoxResult.Yes:
                    break;
                default:
                case MessageBoxResult.No:
                    e.Cancel = true;
                    break;
            }
        }

        private OpenFileDialog openFileDialog = null;
        private const string filtry = "Pliki tekstowe (*.txt)|*.txt|Pliki kodu C# (*.cs)|*.cs|Wszystkie pliki (*.*)|*.*";

        private void miOtwórz_Click(object sender, RoutedEventArgs e)
        {
            if(openFileDialog == null)
            {
                openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Wybierz plik tekstowy...";
                openFileDialog.DefaultExt = "txt";
                openFileDialog.Filter = filtry;
                openFileDialog.FilterIndex = 1;
            }

            if (!string.IsNullOrWhiteSpace(tbŚcieżkaPliku.Text))
                openFileDialog.FileName = tbŚcieżkaPliku.Text;

            bool? wynik = openFileDialog.ShowDialog();
            if(wynik == true)
            {
                tbŚcieżkaPliku.Text = System.IO.Path.GetFileName(openFileDialog.FileName);
                string tekst = File.ReadAllText(openFileDialog.FileName);
                tbTekst.Text = tekst;
            }
        }
        private SaveFileDialog saveFileDialog;
        private void miZapiszJako_Click(object sender, RoutedEventArgs e)
        {
            if (saveFileDialog == null)
            {
                saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Zapisz plik tekstowy";
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.Filter = filtry;
                saveFileDialog.FilterIndex = 1;
            }

            bool? wynik = saveFileDialog.ShowDialog();
            if (wynik == true)
            {
                File.WriteAllText(saveFileDialog.FileName, tbTekst.Text);
                tbŚcieżkaPliku.Text = System.IO.Path.GetFileName(saveFileDialog.FileName);
            }
        }
        
    }
}
