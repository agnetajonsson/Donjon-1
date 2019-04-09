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
            Width = width;
            Height = height;

            cells = new Cell[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    cells[x, y] = new Cell(new Position(x, y), this);
                }
            }
        }

        internal Creature GetCreatureAt(Cell cell)
        {
            foreach (var creature in Creatures)
            {
                if (creature.Cell == cell) return creature;
            }
            return null;
        }

        internal Cell GetCell(Position position) => 
            GetCell(position.X, position.Y);

        internal Cell GetCell(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height) return null;
            return cells[x, y];
        }
    }
}