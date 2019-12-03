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

namespace LabelDragAndDrop
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

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Label l = (sender as Label);

            DataObject data = new DataObject();
            data.SetText(l.Content.ToString());

            DragDrop.DoDragDrop(l, data, DragDropEffects.Copy);
        }

        private void Label_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
            e.Handled = true;
        }

        private void Label_Drop(object sender, DragEventArgs e)
        {
            Label l = (sender as Label);

            l.Content = (e.Data as DataObject).GetText();

            e.Effects = DragDropEffects.Copy;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();

            var value = r.NextDouble().ToString();

            mainLabel.Content = value;
        }
    }
}
