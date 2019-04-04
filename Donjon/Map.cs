using System;
using System.Collections.Generic;

namespace Donjon
{
    internal class Map
    {
        public int Width { get; }
        public int Height { get; }
        private readonly Cell[,] cells;

        public List<Creature> Creatures { get; } = new List<Creature>();

        public Map(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            cells = new Cell[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    cells[x, y] = new Cell();
                }
            }
        }

        internal Cell GetCell(int x, int y) {
            return cells[x, y];
        }
    }
}