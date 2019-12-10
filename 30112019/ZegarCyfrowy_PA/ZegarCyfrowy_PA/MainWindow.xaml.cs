using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
using NtpClient;

namespace ZegarCyfrowy_PA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var klient = new NtpConnection("zegar.umk.pl");
            var data = klient.GetUtc();
            System.Console.WriteLine(data. ToString());
            DispatcherTimer timer = new DispatcherTimer();

            timer.Interval = TimeSpan.FromSeconds(20);
            timer.Tick += timerTick;
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            var time = pobierzCzasNTP();
            pole_zegara.Content = time.ToLongTimeString();//DateTime.Now.ToLongTimeString();
        }

        public DateTime pobierzCzasNTP()
        {
            string ntpSerwer = "zegar.umk.pl";

            var ntpData = new byte[48];
            ntpData[0] = 0x1B;
            var addresses = Dns.GetHostEntry(ntpSerwer).AddressList;
            var ntpIP = new IPEndPoint(addresses[0], 123);

            using ( var socket = new Socket(AddressFamily.InterNetwork, 
                SocketType.Dgram, ProtocolType.Udp))
            {
                socket.Connect(ntpIP);
                socket.ReceiveTimeout = 5000;
                socket.Send(ntpData);
                socket.Receive(ntpData);
                socket.Close();
            }

            var sec = BitConverter.ToInt32(ntpData, 40);
            var ulamekSec = BitConverter.ToInt32(ntpData, 44);

            sec = Swap(sec);
            ulamekSec = Swap(ulamekSec);

            var ms = sec * 1000 + (ulamekSec*1000)/0x100000000L;// + (ulamekSec / 1000);

            var czas = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(ms);
            return czas.ToLocalTime();

            /*Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Connect(ntpIP);
            socket.ReceiveTimeout = 5000;
            socket.Send(ntpData);
            socket.Receive(ntpData);
            socket.Close();*/
        }

        private int Swap(int val)
        {
            return (int) (((val & 0x000000ff) << 24) + 
                          ((val & 0x0000ff00) << 8 ) + 
                          ((val & 0x00ff0000) >> 8) + 
                          ((val & 0xff000000) >> 24)
                         );
        }
    }
}
