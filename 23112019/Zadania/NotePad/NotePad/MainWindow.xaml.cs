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

namespace NotePad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string filters = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
        bool isTextChanged = false;
        OpenFileDialog openFileDialog;
        SaveFileDialog saveFileDialog;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void miClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (!isTextChanged)
                return;

            MessageBoxResult result = MessageBox.Show(this, 
                "Are you sure that you want to close the window without saving?", Title,
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            switch(result)
            {
                case MessageBoxResult.Yes:
                    break;
                default:
                case MessageBoxResult.No:
                    e.Cancel = true;
                    break;
            }
        }

        private void miOpen_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog == null)
            {
                openFileDialog = new OpenFileDialog()
                {
                    Title = "Choose a file to open.",
                    DefaultExt = "txt",
                    Filter = filters,
                    FilterIndex = 1
                };
            }

           if (openFileDialog.ShowDialog() == true)
            {
                string text = File.ReadAllText(openFileDialog.FileName);
                textBuffer.Text = text;

                pathStatusItem.Content = "[ " + System.IO.Path.GetFileName(openFileDialog.FileName) + " ]";
                isTextChanged = false;
                deleteAsterisk();
            }
        }

        private void miWrap_Click(object sender, RoutedEventArgs e)
        {
            textBuffer.TextWrapping = (sender as MenuItem).IsChecked ? TextWrapping.Wrap : TextWrapping.NoWrap;
        }

        private void miUndo_Click(object sender, RoutedEventArgs e)
        {
            textBuffer.Undo();
        }

        private void miCut_Click(object sender, RoutedEventArgs e)
        {
            textBuffer.Cut();
        }

        private void miCopy_Click(object sender, RoutedEventArgs e)
        {
            textBuffer.Copy();
        }

        private void mi_Paste_Click(object sender, RoutedEventArgs e)
        {
            textBuffer.Paste();
        }

        private void mi_Delete_Click(object sender, RoutedEventArgs e)
        {
            textBuffer.SelectedText = "";
        }

        private void mi_SelectAll_Click(object sender, RoutedEventArgs e)
        {
            textBuffer.SelectAll();
        }

        private void mi_PasteDate_Click(object sender, RoutedEventArgs e)
        {
            textBuffer.SelectedText = DateTime.Now.ToString();
        }

        private void textBuffer_TextChanged(object sender, TextChangedEventArgs e)
        {
            isTextChanged = true;

            if (!Title.StartsWith("* ")) Title = "* " + Title;
        }

        private void deleteAsterisk()
        {
            if (Title.StartsWith("* ")) Title = Title.Substring(2);
        }

        private void miStatusBar_Click(object sender, RoutedEventArgs e)
        {
            statusBar.Visibility = (sender as MenuItem).IsChecked ? Visibility.Visible : Visibility.Collapsed;
        }

        private void miSaveAs_Click(object sender, RoutedEventArgs e)
        {
            if (saveFileDialog == null)
            {
                saveFileDialog = new SaveFileDialog()
                {
                    Title = "Save as...",
                    DefaultExt = "txt",
                    Filter = filters,
                    FilterIndex = 1
                };


                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, textBuffer.Text);
                    pathStatusItem.Content = System.IO.Path.GetFileName(saveFileDialog.FileName);
                    isTextChanged = false;
                    deleteAsterisk();
                }
            }
        }
    }
}
