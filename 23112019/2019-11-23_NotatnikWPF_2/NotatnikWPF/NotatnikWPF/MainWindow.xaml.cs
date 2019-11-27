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
        private bool czyTekstZmieniony = false;

        public MainWindow()
        {
            InitializeComponent();

            tbTekst.Focus();
        }

        private void miZakończ_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!czyTekstZmieniony) return;

            MessageBoxResult wynik = MessageBox.Show("Czy na pewno chcesz zamknąć notatnik?", Title, MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (wynik)
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
            if (openFileDialog == null)
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
            if (wynik == true)
            {
                tbŚcieżkaPliku.Text = System.IO.Path.GetFileName(openFileDialog.FileName);
                string tekst = File.ReadAllText(openFileDialog.FileName);
                tbTekst.Text = tekst;
                czyTekstZmieniony = false;
                usuńGwiazdkęZTytułu();
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
                czyTekstZmieniony = false;
                usuńGwiazdkęZTytułu();
            }
        }

        private void usuńGwiazdkęZTytułu()
        {
            if (Title.StartsWith("* ")) Title = Title.Substring(2);
        }

        private void TbTekst_TextChanged(object sender, TextChangedEventArgs e)
        {
            czyTekstZmieniony = true;
            if (!Title.StartsWith("* ")) Title = "* " + Title;

            miCofnij.IsEnabled = tbTekst.CanUndo;
            miPowtórz.IsEnabled = tbTekst.CanRedo;
        }

        /*
         * <MenuItem Header="Cofnij" Click="MenuItem_Click" />
                <MenuItem Header="Powtórz" Click="MenuItem_Click_1" />
                <Separator />
                <MenuItem Header="Wytnij" Click="MenuItem_Click_2" />
                <MenuItem Header="Kopiuj" Click="MenuItem_Click_3" />
                <MenuItem Header="Wklej" Click="MenuItem_Click_4" />
                <Separator />
                <MenuItem Header="Zaznacz wszystko" Click="MenuItem_Click_5" />
                <MenuItem Header="Godzina/data" Click="MenuItem_Click_6" />
        */

        private void miCofnij_Click(object sender, RoutedEventArgs e)
        {            
            tbTekst.Undo();
        }

        private void miPowtórz_Click(object sender, RoutedEventArgs e)
        {
            tbTekst.Redo();
        }

        private void miWytnij_Click(object sender, RoutedEventArgs e)
        {
            tbTekst.Cut();            
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            //Clipboard.SetText(tbTekst.SelectedText);
            tbTekst.Copy();            
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            tbTekst.Paste();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            tbTekst.SelectAll();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            string dataGodzina = DateTime.Now.ToString();
            tbTekst.SelectedText = dataGodzina;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if((e.KeyboardDevice.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                switch(e.Key)
                {
                    case Key.O:
                        miOtwórz_Click(this, null);
                        break;                    
                }
            }
        }

        private void miDrukuj_Click(object sender, RoutedEventArgs e)
        {
            Drukowanie.PrintText(tbTekst.Text);
        }
    }
}
