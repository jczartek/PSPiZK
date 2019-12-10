using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obiektowe1_PA
{
    public class Czlowiek
    {
        public string imie;
        public string nazwisko;
        private string _PESEL;

        public Czlowiek()
        {
            imie = "";
            nazwisko = "";
            _PESEL = "";
        }

        public Czlowiek(string imie, string nazwisko, string PESEL="")
        {
            przypiszWartosci(imie, nazwisko);
            _PESEL = PESEL;
        }

        public Czlowiek(string imie, string nazwisko, DateTime dataUrodzenia)
        {
            przypiszWartosci(imie, nazwisko);
            int cos = 0;
            int suma_kontrolna = 0;
            _PESEL = dataUrodzenia.Year.ToString() + dataUrodzenia.Month.ToString() + dataUrodzenia.Day.ToString() + cos.ToString() + suma_kontrolna.ToString();
        }

        public string przedstawSie()
        {
            podajNumerPesel();
            return imie + " " + nazwisko;
        }

        private string podajNumerPesel()
        {
            return _PESEL;
        }

        private void przypiszWartosci(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
    }

    class Mezczyzna : Czlowiek
    {

    }





    struct Osoba
    {
        public string imie;
        public string nazwisko;
        private string _PESEL;

        // Struktura nie może miec konstruktora bezparametrowego
        /*public Osoba()
        {
            imie = "";
            nazwisko = "";
            _PESEL = "";
        }*/

        // Proteza kontruktora bezparametrowego
        public Osoba(string imie="", string nazwisko="", string PESEL="")
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            _PESEL = PESEL;
        }

        public string przedstawSie()
        {
            return imie + " " + nazwisko;
        }
    }
}
