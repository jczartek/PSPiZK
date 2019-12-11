using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulamek_PA 
{
    class Ulamek : IConvertible
    {
        // 1) licznik i mianownik
        public int licznik { set; get; }
        public int mianownik { set; get; }
        private static int liczba_wystapien { set; get;}
        
        //2) kilka konstruktorów
        static Ulamek()
        {
            liczba_wystapien++;
        }

        public Ulamek(int licznik = 0, int mianownik = 1)
        {
            this.licznik = licznik;
            this.mianownik = mianownik;
        }

        public Ulamek(float wartosc_dziesietna)
        {
            string string_od_dziesietnej = wartosc_dziesietna.ToString();
            int pozycja_kropki = string_od_dziesietnej.IndexOf('.') + 1;
            int dlugosc = string_od_dziesietnej.Length;
            int p = dlugosc - pozycja_kropki;
            this.licznik = (int)(wartosc_dziesietna * Math.Pow(10, p));
            this.mianownik = (int)(Math.Pow(10, p));
        }

        public Ulamek(Ulamek ulamek)
        {
            this.licznik = ulamek.licznik;
            this.mianownik = ulamek.mianownik;
        }

        //3) metoda ToString

        public override string ToString()
        {
            return licznik.ToString() + "/" + mianownik.ToString();
        }

        //4) metoda wartoscDziesietna

        public float wartoscDziesietna()
        {
            return (float)licznik / mianownik;
        }

        //5) dodawanie - ulamek+ulamek, ulamek + int, ulamek + float

        public void dodaj(Ulamek ulamek)
        {
            // 1) sprawdzenie mianownikow
            // 2) sprowadzenie do wspólnego mianownika
            if ( mianownik != ulamek.mianownik )
            {
                int temp_mianownik = mianownik;
                licznik *= ulamek.mianownik;
                mianownik *= ulamek.mianownik;
                ulamek.mianownik *= temp_mianownik;
                ulamek.licznik *= temp_mianownik;
            }
            // 3) dodanie licznikow
            licznik += ulamek.licznik;
        }

        public static Ulamek operator +( Ulamek a, Ulamek b)
        {
            return new Ulamek(a.licznik * b.mianownik + b.licznik * a.mianownik, 
                              a.mianownik * b.mianownik);
        }

        public static Ulamek operator +(Ulamek a, IConvertible b)
        {
            return new Ulamek(); // ToDo
        }

        public static Ulamek operator +( Ulamek a)
        {
            return new Ulamek();
        }

        public static Ulamek dodaj(Ulamek a, Ulamek b)
        {
            Ulamek wynik = new Ulamek(a);
            wynik.dodaj(b);
            return wynik;
            /*if (a.mianownik != b.mianownik)
            {
                int temp_mianownik = a.mianownik;
                a.licznik *= b.mianownik;
                a.mianownik *= b.mianownik;
                b.mianownik *= temp_mianownik;
                b.licznik *= temp_mianownik;
            }
            // 3) dodanie licznikow
            wynik.licznik = a.licznik + b.licznik;
            wynik.mianownik = a.mianownik;
            return wynik;*/
        }
        
        public void dodaj(int wartosc)
        {
            Ulamek nowy_ulamek = new Ulamek(wartosc);
            dodaj(nowy_ulamek);
        }

        public void dodaj(float wartosc)
        {
            Ulamek nowy_ulamek = new Ulamek(wartosc);
            dodaj(nowy_ulamek);
        }

        public TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            return (float)this.wartoscDziesietna();
        }

        public double ToDouble(IFormatProvider provider)
        {
            return (double)this.wartoscDziesietna();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
        //6) odejmowanie

        //7) mnożenie

        //8) dzielenie
    }
}
