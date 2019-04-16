using Donjon.Entities;
using Donjon.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Donjon.World
{
    internal class Map
    {
        public int Width { get; }
        public int Height { get; }
        private readonly Cell[,] cells;

        public List<Creature> Creatures { get; } = new List<Creature>();

        public List<Cell> CellsWithCreature =>
            cells
            .Cast<Cell>()
            .Where(c => c.Creature != null)
            .ToList();

        public Map(int width, int height)
        {
            Width = width;
            Height = height;

            cells = new Cell[width, height];
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    cells[x, y] = new Cell(new Position(x, y), this);
        }

        internal Creature GetCreatureAt(Cell cell) =>
            Creatures.SingleOrDefault(c => c.Cell == cell);

        internal Cell GetCell(Position position) =>
            GetCell(position.X, position.Y);

        internal Cell GetCell(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height) return null;
            return cells[x, y];
        }
    }
}