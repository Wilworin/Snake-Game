using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Game
{
    public struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        //public Position (Position p)
        //{

        //}

        public static bool operator ==(Position x, Position y)
        {
            return (x.X == y.X && x.Y == y.Y);
        }

        public static bool operator !=(Position x, Position y)
        {
            return (x.X != y.X || x.Y != y.Y);
        }

        public override bool Equals(object o) // Never used but implemented to get rid on warnings.
        {
            return (X != ((Position)o).X && Y == ((Position)o).Y);
        }

        public override int GetHashCode() // Never used but implemented to get rid on warnings.
        {
            return base.GetHashCode();
        }

        public static Position operator +(Position x, Position y)
            => new Position(x.X + y.X, x.Y + y.Y);

        public static Position operator -(Position x, Position y)
            => new Position(x.X - y.X, x.Y - y.Y);

    }

    public enum Direction
    {
        None,
        Up,
        Down,
        Right,
        Left
    }

}
