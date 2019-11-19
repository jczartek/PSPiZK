using System;
using System.Windows;


namespace ShowName
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var letter in tbName.Text)
                if (Char.IsDigit(letter) || Char.IsWhiteSpace(letter))
                    throw new ArgumentException("Nie dozowlone litery");

            if (!String.IsNullOrEmpty(tbName.Text))
                MessageBox.Show(tbName.Text);
        }
    }
}
