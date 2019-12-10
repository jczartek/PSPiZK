using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obiektowe1_PA
{
    class Program
    {
        static void Main(string[] args)
        {
            Punkt2D a = new Punkt2D();
            Punkt2D b = new Punkt2D(1, 1);

            Console.WriteLine("a = " + a.ToString());
            Console.WriteLine("b = " + b.ToString());
            Console.ReadKey();

            /*Czlowiek heniek = new Czlowiek();
            Console.WriteLine(heniek.przedstawSie());
            heniek.imie = "Henryk";
            heniek.nazwisko = "Kowalski";

            Mezczyzna czesiek = new Mezczyzna();

            czesiek.imie = "Czesław";
            czesiek.nazwisko = "Kowalski";

            Console.WriteLine(heniek.przedstawSie());
            Console.ReadKey();

            Osoba janek = new Osoba();
            janek.imie = "Jan";
            janek.nazwisko = "Nowak";

            Console.WriteLine(janek.przedstawSie());
            Console.ReadKey();*/
        }
    }
}
