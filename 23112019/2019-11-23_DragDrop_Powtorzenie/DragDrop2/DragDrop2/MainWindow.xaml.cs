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

namespace DragDrop2
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

        private void ListBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DataObject dane = new DataObject();
            dane.SetText("Tekst danych");
            DragDropEffects operacja = DragDrop.DoDragDrop(lbLewy, dane, DragDropEffects.Move | DragDropEffects.Copy);
            if (operacja == DragDropEffects.Move) lbLewy.Items.RemoveAt(0);
        }

        private void LbPrawy_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
            e.Handled = true;
        }

        private void LbPrawy_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Move;
            e.Handled = true;
        }

        private void LbPrawy_Drop(object sender, DragEventArgs e)
        {
            if(e.KeyStates == DragDropKeyStates.ControlKey)
                e.Effects = DragDropEffects.Copy;
            else e.Effects = DragDropEffects.Move;
            ListBox lbSender = sender as ListBox;
            string łańcuchPrzenoszonegoElementu = (e.Data as DataObject).GetText();
            lbSender.Items.Add(new ListBoxItem() { Content = łańcuchPrzenoszonegoElementu });
        }
    }
}
