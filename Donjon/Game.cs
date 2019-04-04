using System;

namespace Donjon
{
    internal class Game
    {
        private Map map;
        private Hero hero;

        public void Run() {
            Initialize();
            Play();
        }

        private void Initialize()
        {
            map = new Map(width: 10, height: 10);

            Cell heroCell = map.GetCell(3, 7);
            hero = new Hero(heroCell);

            map.Creatures.Add(hero);
        }

        private void Play()
        {
            // better as field?
            bool gameInProgress = false;

            do
            {
                Draw();
                // get command from user
                // execute action
                Draw();
                // update game objects
            } while (gameInProgress);
            Draw();
        }

        private void Draw()
        {
            // view.Clear()
            Console.Clear();

            // view.Draw(map)
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    Cell cell  = map.GetCell(x, y);

                    IDrawable drawable = cell;                         

                    // Creature at this position?
                    // Better implemented as 
                    //   cell.Creature ?? cell
                    foreach (var creature in map.Creatures) {
                        if (creature.Cell == cell) {
                            drawable = creature;
                            break;
                        }
                    }

                    Console.ForegroundColor = drawable.Color;
                    Console.Write(" " + drawable.Symbol);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}