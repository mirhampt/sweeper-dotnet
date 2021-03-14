using System;
using Sweeper;

namespace SweeperCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            Console.WriteLine(game);

            while (game.GetGameState() == GameState.InProgress)
            {
                Console.Write("Row: ");
                var row = Int32.Parse(Console.ReadLine() ?? "0");
                Console.Write("Col: ");
                var column = Int32.Parse(Console.ReadLine() ?? "0");

                game.MakeMove(row, column);
                Console.WriteLine(Environment.NewLine + game);
            }
        }
    }
}
