using Donjon.Utilities;
using Donjon.World;

namespace Donjon.Entities
{
    internal class Hero : Creature
    {
        public LimitedList<Item> Backpack { get; } = new LimitedList<Item>(3);

        public Hero(Cell cell) : base(cell)
        {
            Symbol = "H";
            //Color = System.ConsoleColor.Cyan;
        }
    }
}
