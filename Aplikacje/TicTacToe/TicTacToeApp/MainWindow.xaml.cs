using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Model.TicTacToe;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Engine EngineGame { get; }
        public MainWindow()
        {
            
            InitializeComponent();
            EngineGame = (Engine)DataContext;

        }

        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Grid grid = sender as Grid;

            GridExtension.GetRowColumnAt(grid, e.GetPosition(grid), out int row, out int column);

            Label item = GridExtension.GetChildren(grid, row, column) as Label;

            if (item.Content == null)
            {

                item.Content = EngineGame.Turn;
                try
                {
                    EngineGame[row, column] = char.Parse(EngineGame.Turn);

                    if (EngineGame.IsFinished)
                        MessageBox.Show($"Gra skończona! Wygrał: {EngineGame.Winer}");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Label item in gridMain.Children)
                item.Content = null;

            EngineGame.Reset();
        }
    }
}
