using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class DefinitionOfVictory
    {
        public static void LosingMoves(string[] args, int index, string computer_move)
        {
            List<string> losingMoves = args.Skip(index + 1).Take((args.Length - 1) / 2).ToList();

            if (losingMoves.Count() == (args.Length - 1) / 2)
            {
                if (losingMoves.Contains(computer_move))
                {
                    Console.WriteLine("You lose!");
                }
            }
            else
            {
                int remained_count = ((args.Length - 1) / 2) - losingMoves.Count();
                losingMoves.AddRange(args.Take(remained_count));
                if (losingMoves.Contains(computer_move))
                {
                    Console.WriteLine("You Lose!");
                }
            }
        }

        public static void WinningMoves(string[] args, int index, string computer_move)
        {
            List<string> winningMoves = args.Take(index).ToList();

            if (winningMoves.Count > 3)
            {
                winningMoves.Reverse();
                var result = winningMoves.Take(3);

                if (result.Contains(computer_move))
                {
                    Console.WriteLine("You win!");
                }
            }
            else
            {
                var reversed = args.Reverse().ToList();

                winningMoves.AddRange(reversed.Take(((args.Length - 1) / 2) - winningMoves.Count));

                if (winningMoves.Contains(computer_move))
                {
                    Console.WriteLine("You win!");
                }
            }
        }
    }
}
