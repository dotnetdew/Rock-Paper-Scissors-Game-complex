using System;
using System.Reflection;
using RockPaperScissors;
class Program
{
    public static void Main(string[] args)
    {
        if (args.Length < 3 || args.Length % 2 == 0)
        {
            Console.WriteLine("Error: Please provide an odd number >= 3 of non-repeating strings as moves.");
            Console.WriteLine("Example: dotnet run Rock Paper Scissors");
            return;
        }

        HashSet<string> uniqueMoves = new HashSet<string>();

        foreach (string? move in args)
        {
            if (uniqueMoves.Contains(move))
            {
                Console.WriteLine($"Error: The move {move} is repeated. Please provide non-repeating move");
                Console.WriteLine("Example: dotnet run Rock Paper Scissors");
                return;
            }
            uniqueMoves.Add(move);
        }

        while (true)
        {
            start:

            byte[] key = Generation.GenerateKey();

            string computer_move = Generation.GenerateMove(args);

            string HMAC = Generation.CalCulateHMAC(key, computer_move);
            Console.WriteLine($"HMAC: {HMAC} \n");

            Console.WriteLine("Available moves:");

            int i = 0;
            foreach (string move in uniqueMoves)
            {
                i = i + 1;

                Console.WriteLine($"{i}-{move}");
            }

            Console.WriteLine("0-exit");
            Console.WriteLine("?-help");

            Console.Write("Enter your move: ");
            string? userMove = Console.ReadLine();

            if (userMove == "0")
            {
                Console.WriteLine("Good, Bye!");
                return;
            }
            if (userMove == "?")
            {
                TableGeneration.PrintTable(args, computer_move, userMove);

                Console.WriteLine("Press any button to continue");
                Console.ReadKey();
                goto start;
            }

            int index = 0;
            index = Int32.Parse(userMove) - 1;

            string your_move = args[Int32.Parse(userMove) - 1];

            Console.WriteLine($"Your move: {args[Int32.Parse(userMove) - 1]}");
            Console.WriteLine($"Computer move: {computer_move}");

            DefinitionOfVictory.LosingMoves(args, index, computer_move);
            DefinitionOfVictory.WinningMoves(args, index, computer_move);

            string draw = args[index];
            if (computer_move == draw)
            {
                Console.WriteLine("It's draw!");
            }
            Console.WriteLine($"HMAC KEY: {BitConverter.ToString(key).Replace("-", "")} \n\n");
        }
    }

    public static bool HasUniqueStrings(string[] strings)
    {
        List<string> seen = new List<string>();

        foreach (string s in strings)
        {
            if (seen.Contains(s))
                return false;
            else 
                seen.Add(s);
        }
        return true;
    }
}