using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulamek_PA
{
    class Program
    {
        static void Main(string[] args)
        {
            Ulamek a = new Ulamek();
            Ulamek b = new Ulamek(1, 2);

            a.dodaj(b);

            Ulamek c = Ulamek.dodaj(a, b);

            Console.WriteLine( a + b );
            /*Console.WriteLine(a + 1);*/
            // Console.WriteLine(1 + a);
            //a += b;
            int x = 1;
            float y = 0.5f;

            Console.WriteLine(x.GetType());
            Console.WriteLine(y.GetType());
            Console.WriteLine((x+y).GetType());
            //Ulamek c = a + b;

            var osoba = new { imie = "Jan", nazwisko = "Kowalski", PESEL = "00000000"};

            Console.ReadKey();
        }
    }
}
