using System;

namespace Donjon
{
    internal class Creature : IDrawable
    {
        public string Symbol { get; set; } = "C";
        public ConsoleColor Color => ConsoleColor.Cyan;
        public Cell Cell { get; set; }

        public Creature(Cell cell)
        {
            Cell = cell;
        }

    }
}