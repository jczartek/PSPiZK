using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace DataBinding_v2_PA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class Okno : INotifyPropertyChanged
    {
        public string wartosc { set; get; }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propName)
        {
            PropertyChangedEventHandler iHandler = PropertyChanged;

            if ( iHandler == null)
            {
                iHandler(this, new PropertyChangedEventArgs(propName));
            }
        }

    }

    public partial class MainWindow : Window
    {
        Okno okno = new Okno();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = okno;

            okno.wartosc = "HELLO!";

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(changeWartosc);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        public void changeWartosc(object sender, EventArgs e)
        {
            okno.wartosc += "DODANO";
        }
    }
}
