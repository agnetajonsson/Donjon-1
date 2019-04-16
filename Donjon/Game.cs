using Donjon.Entities;
using Donjon.Utilities;
using Donjon.World;
using System;
using System.Linq;

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

            map.GetCell(5, 8).Items.Add(Item.DirtySock());
            map.GetCell(2, 3).Items.Add(Item.MundaneRock ());
            map.GetCell(2, 3).Items.Add(Item.Coin());
            map.GetCell(2, 6).Items.Add(Item.Coin());
            map.GetCell(5, 2).Items.Add(Item.Coin());
            map.GetCell(1, 1).Items.Add(Item.Coin());
            map.GetCell(8, 8).Items.Add(Item.Coin());
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
                    case ConsoleKey.P:
                        PickUp();
                        break;
                    case ConsoleKey.I:
                        Inventory();
                        break;
                }


                // execute action
                Draw();
                // update game objects
            } while (gameInProgress);
            Draw();
        }

        private void Inventory()
        {
            foreach (var item in hero.Backpack)
            {
                Console.WriteLine(item);
            }
        }

        private void PickUp()
        {
            var items = hero.Cell.Items;
            var item = items.FirstOrDefault();
            if (item == null) return;            
            if (hero.Backpack.Add(item)) items.Remove(item);
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