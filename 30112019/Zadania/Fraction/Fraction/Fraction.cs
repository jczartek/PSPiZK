using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rational
{
    public class Fraction
    {
        public int Numer { get; set; }
        public int Denom { get; set; }

        public Fraction(int n = 0, int d = 1) { Numer = n; Denom = d; }

        public Fraction(int number) : this(n: number) { }

        public Fraction(double value)
        {
            int precision = value.ToString().Length - (value.ToString().IndexOf(".") + 1);

            Numer = (int) (value * Math.Pow(10, precision));
            Denom = (int)(Math.Pow(10, precision));
        }

        public override string ToString()
        {
            return string.Format($"{Numer}/{Denom}");
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            int numer = (f1.Numer * f2.Denom) + (f2.Numer * f1.Denom);
            int denom = f1.Denom * f2.Denom;
            return new Fraction(numer, denom);
        }

        public static Fraction operator +(Fraction f, int value)
        {
            return f + new Fraction(value);
        }

        public static Fraction operator +(Fraction f, double value)
        {
            return f + new Fraction(value);
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            int numer = (f1.Numer * f2.Denom) - (f2.Numer * f1.Denom);
            int denom = f1.Denom * f2.Denom;
            return new Fraction(numer, denom);
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            int numer = f1.Numer * f2.Numer;
            int denom = f1.Denom * f2.Denom;

            return new Fraction(numer, denom);
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            int numer = f1.Numer * f2.Denom;
            int denom = f1.Denom * f2.Numer;

            return new Fraction(numer, denom);
        }
    }
}
