using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExercies
{
    class Program
    {
        static void Main(string[] args)
        {
            RownanieKwadratowe();
            Console.ReadKey();
        }

        static void RownanieKwadratowe()
        {
            Console.Write("Podaj a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Podaj b: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Podaj c: ");
            double c = Convert.ToDouble(Console.ReadLine());

            double delta = (b * b) - 4 * a * c;

            if (delta < 0) Console.WriteLine("Równanie nie ma rozwiązania!");
            else if (delta == 0) Console.WriteLine($"Równanie ma jedno rozwiązanie x1: { -b / ( 2*a ) : 0.00}");
            else
            {
                double delta_sqrt = Math.Sqrt(delta);
                Console.WriteLine($"Równanie ma dwa rozwiązania x1: {-b - delta_sqrt / (2 * a) : 0.00}\t " +
                                                              $"x2: {-b + delta_sqrt / (2 * a) : 0.00}");
            }
        }
    }
}
