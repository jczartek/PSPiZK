using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obiektowe1_PA
{
    class Punkt2D
    {
        private int _x;
        private int _y;

        /* Udostępnienie pól prywatnych - metoda 1 - brzydka*/
        public int x()
        {
            return _x;
        }

        public void x(int val)
        {
            _x = val;
        }

        /* Udostępnienie pól prywatnych - metoda 2 - brzydka*/
        public int getX()
        {
            return _x;
        }

        public void setX(int val)
        {
            _x = val;
        }

        /* Udostępnienie pól prywatnych - metoda 3 - ładna*/
        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        /* Udostępnienie pól prywatnych - metoda 4 - optymalna (najmniej pracochłonna) - auto properties */
        public int punktX { set; get; }

        public Punkt2D(int x=0, int y=0)
        {
            _x = x;
            _y = y;
        }

        /* override, bo dziedziczy po object */
        public override string ToString()
        {
            return "[" + _x + ", " + _y + "]";
        }

        public float odleglosc(Punkt2D punkt)
        {
            return Math.Sqrt( (punkt.)
        }

    }
}
