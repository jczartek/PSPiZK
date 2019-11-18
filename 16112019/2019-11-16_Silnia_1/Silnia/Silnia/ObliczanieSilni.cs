namespace Umk
{
    public static class ObliczanieSilni
    {
        public static long Oblicz(int n)
        {
            if (n <= 1) return 1;
            long wynik = 1;
            for (long i = 2; i <= n; i++)
            {
                //wynik = wynik * i;
                checked
                {
                    wynik *= i;
                }
                
            }
            return wynik;
        }
    }
}
