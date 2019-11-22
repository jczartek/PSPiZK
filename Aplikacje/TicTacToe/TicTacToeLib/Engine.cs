using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Engine
    {
        public bool IsFinished { get; private set; } = false;
        public string Winer { get; private set; }
        private readonly char[,] table = new char[3, 3];
        
        public char this [int row, int column]
        {
            set
            {
                if (IsFinished == true)
                    throw new Exception("Game is over. You can't set any fields!");
      
                table[row, column] = value;
                Check();
            }
        }

        public void Reset()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    table[i,j] = default(char);
            IsFinished = false;
            Winer = "";
        }

        public void Check()
        {
            char sign;

            // Diagonals
            sign = table[0, 0];
            if (sign != default(char) && table[1,1] == sign && table[2,2] == sign)
            {
                IsFinished = true;
                Winer = sign.ToString();
                return;
            }

            sign = table[2, 0];
            if (sign != default(char) && table[1, 1] == sign && table[0, 2] == sign)
            {
                IsFinished = true;
                Winer = sign.ToString();
                return;
            }

            // Rows
            sign = table[0, 0];
            if (sign != default(char) && table[0, 1] == sign && table[0, 2] == sign)
            {
                IsFinished = true;
                Winer = sign.ToString();
                return;
            }

            sign = table[1, 0];
            if (sign != default(char) && table[1, 1] == sign && table[1, 2] == sign)
            {
                IsFinished = true;
                Winer = sign.ToString();
                return;
            }

            sign = table[2, 0];
            if (sign != default(char) && table[2, 1] == sign && table[2, 2] == sign)
            {
                IsFinished = true;
                Winer = sign.ToString();
                return;
            }

            // Columns
            sign = table[0, 0];
            if (sign != default(char) && table[1, 0] == sign && table[2, 0] == sign)
            {
                IsFinished = true;
                Winer = sign.ToString();
                return;
            }

            sign = table[0, 1];
            if (sign != default(char) && table[1, 1] == sign && table[2, 1] == sign)
            {
                IsFinished = true;
                Winer = sign.ToString();
                return;
            }

            sign = table[0, 2];
            if (sign != default(char) && table[1, 2] == sign && table[2, 2] == sign)
            {
                IsFinished = true;
                Winer = sign.ToString();
                return;
            }

            // Check if the draw           
            bool isDraw = Array.TrueForAll<char>(table.Cast<char>().ToArray(), // Flat table
                                                 item => item == 'X' || item == 'O' );
            if (isDraw)
            {
                IsFinished = true;
                Winer = "Nobody";
            }
        }
    }
}
