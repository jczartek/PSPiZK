using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obiektowe2_PA
{
    class Pies : Zwierze, IGłosowy
    {
        public Pies(string rodzaj, string  gatunek, string imie) : base(rodzaj, gatunek, imie)
        {

        }
        public string dajGłos()
        {
            return "HAU, HAU";
        }
    }
}
