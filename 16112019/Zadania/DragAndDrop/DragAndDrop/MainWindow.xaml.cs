using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DragAndDrop
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

        private void ListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListBox source = sender as ListBox;
            ListBoxItem item = ListBoxExtensions.GetItemAt(source, e.GetPosition(source));

            if (item != null)
            {
                DataObject data = new DataObject();
                data.SetData("Source", source);
                data.SetData("MovedItem", item);
                DragDrop.DoDragDrop(source, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        private void ListBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.KeyStates.HasFlag(DragDropKeyStates.ControlKey))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.Move;
            e.Handled = true;

        }

        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            ListBox destination = sender as ListBox;
            ListBox source = e.Data.GetData("Source") as ListBox;
            ListBoxItem item = e.Data.GetData("MovedItem") as ListBoxItem;

            if (!e.KeyStates.HasFlag(DragDropKeyStates.ControlKey))
                source.Items.Remove(item);
            else
                item = new ListBoxItem { Content = item.Content };

            int idx = ListBoxExtensions.IndexFromPoint(destination, e.GetPosition(destination));

            if (idx < 0)
                destination.Items.Add(item);
            else
                destination.Items.Insert(idx, item);

        }
    }
}
