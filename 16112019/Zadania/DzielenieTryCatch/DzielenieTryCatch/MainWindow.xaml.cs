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

namespace DzielenieTryCatch
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

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(tbA.Text) || String.IsNullOrEmpty(tbB.Text))
                return;

            if (!String.IsNullOrEmpty(tblError.Text))
                tblError.Text = "";

            try
            {
                int a = int.Parse(tbA.Text);
                int b = int.Parse(tbB.Text);
                int result = a / b;

                lResult.Content = result.ToString();
            } catch (DivideByZeroException exn)
            {
                tblError.Text = exn.Message;
            } catch (Exception exn)
            {
                tblError.Text = exn.Message;
            }
        }
    }
}
