using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PrzeciagnicIUpusc
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

        private void listBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ListBox lbSender = (ListBox)sender;
            int indeks = ListBoxExtensions.IndexFromPoint(lbSender, e.GetPosition(lbSender));
            ListBoxItem przenoszonyElement = (ListBoxItem)lbSender.Items[indeks];
            DataObject dane = new DataObject();
            dane.SetText(przenoszonyElement.Content.ToString());
            DragDropEffects operacja = DragDrop.DoDragDrop(lbSender, dane, DragDropEffects.Move | DragDropEffects.Copy);
            //takie sobie obejście - lepiej wykorzystać effect
            if (!Keyboard.IsKeyDown(Key.LeftCtrl)) lbSender.Items.Remove(przenoszonyElement);
        }

        private void listBox_DragOver(object sender, DragEventArgs e)
        {
            if (e.KeyStates.HasFlag(DragDropKeyStates.ControlKey))
                e.Effects = DragDropEffects.Copy;
            else e.Effects = DragDropEffects.Move;
            //e.Handled = true; //?????
        }

        private void listBox_Drop(object sender, DragEventArgs e)
        {
            ListBox lbSender = (ListBox)sender;
            string etykieta = ((DataObject)e.Data).GetText();
            lbSender.Items.Add(etykieta);
        }
    }

    public static class ListBoxExtensions
    {
        public static ListBoxItem GetItemAt(ListBox listBox, Point position)
        {
            //kod skopiowany ze StackOverflow
            DependencyObject o = VisualTreeHelper.HitTest(listBox, position).VisualHit;
            while(o != null && !(o is ListBoxItem))
            {
                o = VisualTreeHelper.GetParent(o);
            }
            return (ListBoxItem)o;
        }

        public static int IndexFromPoint(ListBox listBox, Point position)
        {
            ListBoxItem item = GetItemAt(listBox, position);
            return listBox.Items.IndexOf(item);
        }
    }
}
