using Donjon.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Donjon
{
    static class UI
    {
        public static void Clear() {
            Console.CursorVisible = false;
            Console.Clear();
            Console.SetCursorPosition(0, 0);            
        }

        public static ConsoleKey GetKey() {
            return Console.ReadKey(intercept: true).Key;
        }

        public static void SetColor(ConsoleColor color) {
            Console.ForegroundColor = color;
        }

        public static void Draw(Map map)
        {
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    Cell cell = map.GetCell(x, y);
                    IDrawable drawable = cell.Creature ?? cell.Items.FirstOrDefault() ?? (IDrawable)cell;

                    //foreach (var creature in map.Creatures)
                    //{
                    //    if (creature.Cell == cell)
                    //    {
                    //        drawable = creature;
                    //        break;
                    //    }
                    //}

                    Console.ForegroundColor = drawable.Color;
                    Console.Write(" " + drawable.Symbol);
                }
                Console.WriteLine();
            }
        }
    }
}
