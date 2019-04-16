using Donjon.Entities;
using Donjon.Utilities;
using Donjon.World;
using System;
using System.Collections.Generic;

namespace Donjon.World
{
    internal class Cell : IDrawable
    {
        private readonly Map map;

        public string Symbol => ".";
        public ConsoleColor Color => ConsoleColor.DarkGray;

        public List<Item> Items { get; } = new List<Item>();

        public Creature Creature => map.GetCreatureAt(this);

        public Position Position { get; }

        public Cell(Position position, Map map)
        {
            Position = position;
            this.map = map;
        }

    }
}