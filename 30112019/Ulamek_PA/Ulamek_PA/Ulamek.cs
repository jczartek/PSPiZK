using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulamek_PA
{
    class Ulamek
    {
        // 1) licznik i mianownik
        public int licznik { set; get; }
        public int mianownik { set; get; }
        
        //2) kilka konstruktorów
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
        //6) odejmowanie

        //7) mnożenie

        //8) dzielenie
    }
}
