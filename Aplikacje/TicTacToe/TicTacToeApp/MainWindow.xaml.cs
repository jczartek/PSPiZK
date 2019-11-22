using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Sign { get; set; } = "X";
        public Engine EngineGame { get; }
        public MainWindow()
        {
            EngineGame = new Engine();
            InitializeComponent();
            this.DataContext = this;

        }

        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Grid grid = sender as Grid;

            GridExtension.GetRowColumnAt(grid, e.GetPosition(grid), out int row, out int column);

            Label item = GridExtension.GetChildren(grid, row, column) as Label;

            if (item.Content == null)
            {

                item.Content = Sign;
                try
                {
                    EngineGame[row, column] = char.Parse(Sign);

                    if (EngineGame.IsFinished)
                        MessageBox.Show($"Gra skończona! Wygrał: {EngineGame.Winer}");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }


                Sign = Sign == "X" ? "O" : "X";
                runTurn.GetBindingExpression(Run.TextProperty).UpdateTarget();


            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Label item in gridMain.Children)
                item.Content = null;

            Sign = "X";
            EngineGame.Reset();
            runTurn.GetBindingExpression(Run.TextProperty).UpdateTarget();
        }
    }
}
