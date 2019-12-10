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

namespace ZegarAnalogowy_PA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double sec;
        private double min;
        private double h;

        private Line wskazowkaSec;
        private Line wskazowkaMin;
        private Line wskazowkaH;

        public MainWindow()
        {
            InitializeComponent();

            myCanvas.Width = 300;
            myCanvas.Height = 300;

            RysujTarcze();
            RysujWskazowki();
        }

        private void RysujWskazowke(Wskazowka wskazowka)
        {
            Line linia_wskazowki = new Line();
            linia_wskazowki.Stroke = wskazowka.stroke;
            linia_wskazowki.StrokeThickness = wskazowka.thickness;
            linia_wskazowki.X1 = myCanvas.Width / 2;
            linia_wskazowki.Y1 = myCanvas.Height / 2;

            linia_wskazowki.X2 = myCanvas.Width / 2;
            linia_wskazowki.Y2 = //DŁUGOŚĆ WSKAZÓWKI z klasy wskazowka

        }

        private void RysujTarcze()
        {
            Ellipse tarcza = new Ellipse();
            tarcza.Width = 300;
            tarcza.Height = 300;
            tarcza.Stroke = Brushes.Black;
            tarcza.StrokeThickness = 2;

            myCanvas.Children.Add(tarcza);

            Line[] podzialka = new Line[60];

            for (int i=0; i<60; i++)
            {
                podzialka[i] = new Line();
                podzialka[i].Stroke = Brushes.Black;

                if ( i % 5 == 0 )
                {
                    podzialka[i].StrokeThickness = 4;
                }
                else
                {
                    podzialka[i].StrokeThickness = 2;
                }
                podzialka[i].X1 = tarcza.Width/2;
                podzialka[i].Y1 = 0;

                podzialka[i].X2 = tarcza.Width/2;
                podzialka[i].Y2 = 10;

                RotateTransform transformacja = new RotateTransform(6 * i);
                transformacja.CenterX = tarcza.Width / 2;
                transformacja.CenterY = tarcza.Height / 2;

                podzialka[i].RenderTransform = transformacja;

                myCanvas.Children.Add(podzialka[i]);
            }

           


        }
    }
}
