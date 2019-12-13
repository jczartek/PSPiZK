using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.TicTacToe
{
    public class Engine : INotifyPropertyChanged
    {
        private bool isFinished = false;
        public bool IsFinished
        {
            get
            {
                return isFinished;
            }
            private set
            {
                isFinished = value;
                OnNotifyPropertyChanged("IsFinished");
            }
        }

        private string winerGame;
        public string Winer
        {
            get
            {
                return winerGame;
            }
            private set
            {
                winerGame = value;
                OnNotifyPropertyChanged("Winer");
            }
        }

        private string turn = new Random().Next(2) == 1 ? "X" : "O";
        public string Turn
        {
            get
            {
                return turn;
            }
            set
            {
                turn = value;
                OnNotifyPropertyChanged("Turn");
            }
        }
        private readonly char[,] table = new char[3, 3];

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public char this [int row, int column]
        {
            set
            {
                if (IsFinished == true)
                    throw new Exception("Game is over. You can't set any fields!");
      
                table[row, column] = value;
                
                Check();
                Turn = Turn == "X" ? "O" : "X";
            }
        }

        public void Reset()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    table[i,j] = default(char);
            IsFinished = false;
            Winer = "";
            Turn = new Random().Next(2) == 1 ? "X" : "O";
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
                Turn = "Nobody";
            }
        }
    }
}
