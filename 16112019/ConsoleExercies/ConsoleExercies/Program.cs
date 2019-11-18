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
            //RownanieKwadratowe();
            //PodajImie();
            //DzienTygodnia();
            //Kalkulator();
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

        static void PodajImie()
        {
            Console.Write("Podaj imię: ");
            string name = Console.ReadLine().Trim();

            if (String.IsNullOrEmpty(name)) return;

            Console.WriteLine(name.EndsWith("a") ? $"Imię żeński: {name}" : $"Imię męskie: {name}");
        }

        static void DzienTygodnia()
        {
            Console.Write("Podaj numer dnia (1-7): ");
            int numerDnia = Convert.ToInt32(Console.ReadLine());

            string dzienTygodnia = null;

            switch(numerDnia)
            {
                case 1:
                    dzienTygodnia = "Poniedziałek";
                    break;
                case 2:
                    dzienTygodnia = "Wtorek";
                    break;
                case 3:
                    dzienTygodnia = "Środa";
                    break;
                case 4:
                    dzienTygodnia = "Czwartek";
                    break;
                case 5:
                    dzienTygodnia = "Piątek";
                    break;
                case 6:
                    dzienTygodnia = "Sobota";
                    break;
                case 7:
                    dzienTygodnia = "Niedziela";
                    break;
                default:
                    Console.WriteLine($"Błąd: {numerDnia}");
                    return;
            }

            Console.WriteLine($"Numer dnia: {numerDnia}  to dzień tygodnia: {dzienTygodnia} ");
        }

        static void Kalkulator()
        {
            Console.WriteLine("Witaj w Kalkulatorze!");

            while(true)
            {
                Console.Write("Wybierz dostępne operacje (+, -, *, /, ^, %, exit): ");
                string op = Console.ReadLine().Trim();

                if (op == "exit") break;

                Console.Write("Podaj liczbę a: ");
                double a = double.Parse(Console.ReadLine());

                Console.Write("Podaj liczbę b: ");
                double b = double.Parse(Console.ReadLine());

                double result;

                switch(op)
                {
                    case "+":
                        result = a + b;
                        break;
                    case "-":
                        result = a - b;
                        break;
                    case "*":
                        result = a * b;
                        break;
                    case "/":
                        if (b == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Dzielenie przez 0!");
                            Console.ResetColor();
                            continue;
                        }
                        result = a / b;
                        break;
                    case "^":
                        result = Math.Pow(a, b);
                        break;
                    case "%":
                        result = a % b;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"Niedozwolona operacja: {op}!");
                        Console.ResetColor();
                        continue;
                }

                Console.Clear();
                Console.WriteLine($"Wynik: {result}");
            }

            Console.WriteLine("Żegnaj!");
        }
    }
}
