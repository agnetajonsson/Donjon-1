using System;
using System.Collections.Generic;
using System.Text;

namespace Donjon
{
    struct Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Position operator +(Position p1, Position p2) => 
            new Position(p1.X + p2.X, p1.Y + p2.Y);

        public static Position operator -(Position p) => 
            new Position(-p.X, -p.Y);

        public static Position operator -(Position p1, Position p2) => 
            p1 + (-p2);
    }
}