using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obiektowe2_PA
{
    class Zwierze
    {
        string imie { set; get; }
        string rodzaj { set; get; }
        string gatunek { set; get; }

        public Zwierze()
        {

        }

        public Zwierze(string rodzaj, string gatunek, string imie)
        {
            this.imie = imie;
            this.gatunek = gatunek;
            this.rodzaj = rodzaj;
        }
    }
}
