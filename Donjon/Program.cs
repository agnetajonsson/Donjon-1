using System;

namespace Donjon
{
    class Program
    {

        static void Main(string[] args)
        {
            var game = new Game();
            game.Run();

            Console.WriteLine("Thanks for playing");
            Console.ReadKey();
        }
    }
}
