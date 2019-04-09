using System;

namespace Donjon
{
    internal class Game
    {
        private Map map;
        private Hero hero;

        public void Run()
        {
            Initialize();
            Play();
        }

        private void Initialize()
        {
            map = new Map(width: 10, height: 10);

            Cell heroCell = map.GetCell(3, 7);
            hero = new Hero(heroCell);

            map.Creatures.Add(hero);
            map.Creatures.Add(new Creature(map.GetCell(7, 8)));
        }

        private void Play()
        {
            // better as field?
            bool gameInProgress = true;

            do
            {
                Draw();
                // get command from user
                var key = UI.GetKey();

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        MoveHero(new Position(0, -1));
                        break;
                    case ConsoleKey.DownArrow:
                        MoveHero(new Position(0, 1));
                        break;
                    case ConsoleKey.LeftArrow:
                        MoveHero(new Position(-1, 0));
                        break;
                    case ConsoleKey.RightArrow:
                        MoveHero(new Position(1, 0));
                        break;
                    case ConsoleKey.Q:
                        gameInProgress = false;
                        break;
                }


                // execute action
                Draw();
                // update game objects
            } while (gameInProgress);
            Draw();
        }

        private void MoveHero(Position movement)
        {
            var newPosition = hero.Cell.Position + movement;
            Cell targetCell = map.GetCell(newPosition);
            if (targetCell != null && targetCell.Creature == null) hero.Cell = targetCell;
        }

        private void Draw()
        {
            UI.Clear();
            UI.Draw(map);
            UI.SetColor(ConsoleColor.White);
        }
    }
}