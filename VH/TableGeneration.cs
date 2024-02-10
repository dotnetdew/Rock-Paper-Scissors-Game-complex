using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class TableGeneration
    {
        public static void PrintTable(string[] moves, string computer_move, string user_move)
        {
            var table = new ConsoleTable();
            table.Columns.Add("/////");
            table.AddColumn(moves);

            int p = (int)Math.Floor((double)moves.Length / 2);

            for (int i = 1; i < moves.Length + 1; i++)
            {
                string[] row = new string[moves.Length + 1];
                row[0] = moves[i - 1];

                for(int j = 1; j < moves.Length + 1; j++)
                {
                    int sign = Math.Sign((i - j + p + moves.Length) % moves.Length - p);

                    if (sign == 0)
                        row[j] = "Draw";
                    else if (sign == 1)
                        row[j] = "Win";
                    else
                        row[j] = "Lose";
                }
                table.Rows.Add(row);
            }

            table.Write(Format.Alternative);
        }
    }
}
