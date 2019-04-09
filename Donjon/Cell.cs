using System;
using System.Collections.Generic;

namespace Donjon
{
    internal class Cell : IDrawable
    {
        private readonly Map map;

        public string Symbol => ".";
        public ConsoleColor Color => ConsoleColor.DarkGray;

        public List<Item> Items { get; } = new List<Item>();

        // get the actual Creature from 
        //   map.Creature.SingleOrDefault(c => c.Cell == this)
        // Inject as lambda
        public Creature Creature => map.GetCreatureAt(this);

        public Position Position { get; }

        public Cell(Position position, Map map)
        {
            Position = position;
            this.map = map;
        }

    }
}