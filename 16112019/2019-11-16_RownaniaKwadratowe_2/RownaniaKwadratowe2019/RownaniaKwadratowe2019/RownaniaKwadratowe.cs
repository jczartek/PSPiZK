using System;

namespace RownaniaKwadratowe2019
{
    public  class RównanieKwadratowe
    {
        public Wyniki Oblicz(double a, double b, double c)
        {
            double delta = b * b - 4 * a * c;
            if (delta < 0) throw new Exception("Równanie nie ma rozwiązań");

            //obliczanie wyników
            double pierwiastedDelta = Math.Sqrt(delta);
            double x1 = (-b - pierwiastedDelta) / (2 * a);
            double x2 = (-b + pierwiastedDelta) / (2 * a);

            //przygotowanie zwracanego obiektu
            Wyniki wyniki = new Wyniki();
            wyniki.X1 = x1;
            wyniki.X2 = x2;
            return wyniki;
        }

        public class Wyniki
        {
            public double X1, X2;
        }
    }
}
