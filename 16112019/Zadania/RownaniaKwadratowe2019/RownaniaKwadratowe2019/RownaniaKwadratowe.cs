using System;
using System.Numerics;

namespace RownaniaKwadratowe2019
{
    public  class RównanieKwadratowe
    {
        public Wyniki Oblicz(Complex a, Complex b, Complex c)
        {
             
            Complex delta = b * b - 4 * a * c;
            if (delta.Real < 0) throw new Exception("Równanie nie ma rozwiązań");

            //obliczanie wyników
            Complex pierwiastedDelta = Complex.Sqrt(delta);
            Complex x1 = (-b - pierwiastedDelta) / (2 * a);
            Complex x2 = (-b + pierwiastedDelta) / (2 * a);

            //przygotowanie zwracanego obiektu
            Wyniki wyniki = new Wyniki();
            wyniki.X1 = x1;
            wyniki.X2 = x2;
            return wyniki;
        }

        public class Wyniki
        {
            public Complex X1, X2;
        }
    }
}
