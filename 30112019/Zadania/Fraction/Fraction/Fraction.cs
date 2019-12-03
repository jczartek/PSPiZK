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
        int _denon;
        public int Denom
        {
            get { return _denon; }
            set
            {
                if (value == 0)
                    throw new ArgumentException("0 can't be the denominator!");

                _denon = value;
            }
        }

        public Fraction(int n = 0, int d = 1) { Numer = n; Denom = d; }

        public Fraction(int number) : this(n: number) { }

        public Fraction(double value)
        {
            int precision = value.ToString().Length - (value.ToString().IndexOf(".") + 1);

            Numer = (int)(value * Math.Pow(10, precision));
            Denom = (int)(Math.Pow(10, precision));
        }

        public Fraction(string fraction)
        {
            string[] elements = fraction.Split('/');
            Numer = int.Parse(elements[0]);
            Denom = int.Parse(elements[1]);
        }

        public override string ToString()
        {
            _reduceFraction();
            return string.Format($"{Numer}/{Denom}");
        }

        private void _reduceFraction()
        {
            int gcd = _gcd(Numer, Denom);

            Numer /= gcd;
            Denom /= gcd;
        }

        public double GetDecimalValue()
        {
            return (double)Numer / (double)Denom;
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

        public static Fraction operator +(int value, Fraction f)
        {
            return f + value;
        }

        public static Fraction operator +(Fraction f, double value)
        {
            return f + new Fraction(value);
        }

        public static Fraction operator +(double value, Fraction f)
        {
            return f + value;
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            int numer = (f1.Numer * f2.Denom) - (f2.Numer * f1.Denom);
            int denom = f1.Denom * f2.Denom;
            return new Fraction(numer, denom);
        }
        public static Fraction operator -(Fraction f, int value)
        {
            return f - new Fraction(value);
        }

        public static Fraction operator -(int value, Fraction f)
        {
            return new Fraction(value) - f;
        }

        public static Fraction operator -(Fraction f, double value)
        {
            return f - new Fraction(value);
        }

        public static Fraction operator -(double value, Fraction f)
        {
            return new Fraction(value) - f;
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            int numer = f1.Numer * f2.Numer;
            int denom = f1.Denom * f2.Denom;

            return new Fraction(numer, denom);
        }

        public static Fraction operator *(Fraction f, int value)
        {
            return f * new Fraction(value);
        }

        public static Fraction operator *(int value, Fraction f)
        {
            return f * value;
        }

        public static Fraction operator *(Fraction f, double value)
        {
            return f * new Fraction(value);
        }

        public static Fraction operator *(double value, Fraction f)
        {
            return f * value;
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            int numer = f1.Numer * f2.Denom;
            int denom = f1.Denom * f2.Numer;

            return new Fraction(numer, denom);
        }

        public static Fraction operator /(Fraction f, int value)
        {
            return f / new Fraction(value);
        }

        public static Fraction operator /(int value, Fraction f)
        {
            return new Fraction(value) / f;
        }

        public static Fraction operator /(Fraction f, double value)
        {
            return f / new Fraction(value);
        }

        public static Fraction operator /(double value, Fraction f)
        {
            return new Fraction(value) / f;
        }

        private static int _gcd(int a, int b)
        {
            int Remainder;

            while (b != 0)
            {
                Remainder = a % b;
                a = b;
                b = Remainder;
            }

            return a;
        }
    }
}
