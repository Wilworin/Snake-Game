using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Game
{
    /// <summary>
    /// Holds all info about a certain Tail segment.
    /// </summary>
    public class Tail : GameObject, IRenderable
    {
        public char Look { get; set; } = 'o';

        public Tail(Position p) : base(p)
        {
        }
        public Tail(int x, int y) : base(x, y)
        {
        }
    }
}
