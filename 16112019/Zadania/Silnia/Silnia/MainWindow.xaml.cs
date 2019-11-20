using System.Windows;

namespace Silnia
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int liczba = int.Parse(tb1.Text);
                long silnia = Umk.ObliczanieSilni.Oblicz(liczba);
                run1.Text = silnia.ToString();
            }
            catch
            {
                MessageBox.Show("Coś nie gra");
            }
        }
    }
}
