using System;

namespace Donjon.Entities
{
    public class Item : IDrawable
    {
        private readonly string name;
        public string Symbol { get; }
        public ConsoleColor Color { get; }

        private Item(string name, string symbol, ConsoleColor color)
        {
            this.name = name;
            Symbol = symbol;
            Color = color;
        }

        public static Item DirtySock() => new Item("dirty sock", "s", ConsoleColor.Gray);
        public static Item MundaneRock() => new Item("mundane rock", "r", ConsoleColor.Gray);
        public static Item Coin() => new Item("coin", "c", ConsoleColor.Yellow);

        public override string ToString() => name;
    }
}