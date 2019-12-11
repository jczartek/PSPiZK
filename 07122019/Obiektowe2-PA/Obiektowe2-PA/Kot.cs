using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obiektowe2_PA
{
    class Kot : Zwierze, IGłosowy
    {
       /* public Kot(string rodzaj, string gatunek, string imie) : base(rodzaj, gatunek, imie)
        {

        }*/
        public string dajGłos()
        {
            return "MIAU, MIAU";
        }
    }
}
