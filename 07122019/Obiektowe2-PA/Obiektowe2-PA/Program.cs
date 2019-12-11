using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obiektowe2_PA
{
    class Program
    {
        static void Main(string[] args)
        {
            Pies pies = new Pies("Pies", "Domowy", "Burek");
            Kot filemon = new Kot();

            Zwierze[] tablica_zwierzat = new Zwierze[10];
            
            tablica_zwierzat[0] = pies;
            tablica_zwierzat[1] = filemon;  
           
            Console.WriteLine(pies.dajGłos());
            Console.WriteLine(kot.dajGłos());
            Console.ReadKey();
        }
    }
}
