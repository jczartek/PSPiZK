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
            a += b;

            Ulamek c = a + b;

            Console.WriteLine(a.wartoscDziesietna().ToString());
            Console.WriteLine(b.wartoscDziesietna().ToString());
            Console.ReadKey();
        }
    }
}
