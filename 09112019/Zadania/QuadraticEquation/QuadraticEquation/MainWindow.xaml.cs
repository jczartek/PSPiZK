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

namespace QuadraticEquation
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

        private void Bt_Click(object sender, RoutedEventArgs e)
        {
            double a = Convert.ToDouble(tbA.Text);
            double b = Convert.ToDouble(tbB.Text);
            double c = Convert.ToDouble(tbC.Text);

            string resultx1, resultx2;
            resultx1 = Double.NaN.ToString();
            resultx2 = Double.NaN.ToString();

            double delta = (b * b) - 4 * a * c;

            if (delta > 0)
            {
                double x1, x2;

                x1 = (-b - Math.Sqrt(delta) / (2 * a));
                x2 = (-b + Math.Sqrt(delta) / (2 * a));

                resultx1 = String.Format($"x1: {x1}");
                resultx2 = String.Format($"x2: {x2}");
            }
            else if (delta == 0)
            {
                double x;

                x = -b / (2 * a);

                resultx1 = String.Format($"x: {x}");
            }

            tblx1.Text = resultx1;
            tblx2.Text = resultx2;
        }
    }
}
