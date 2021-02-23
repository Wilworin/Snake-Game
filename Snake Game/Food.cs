using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Game
{
    /// <summary>
    /// Holds all information about the Food.
    /// </summary>
    public class Food : GameObject, IRenderable
    {
        public char Look { get; } = '*';

        public Food ()
        {
            Random r = new Random();
            int x = r.Next(2, Program.ConsoleWidth-1);
            int y = r.Next(4, Program.ConsoleHeight-1);
            Pos = new Position(x, y);
        }

        //public Food(Position p)
        //{
        //    Pos = p;
        //}

        public Food(int x, int y):base (x,y)
        {
           
        }

        public override void Update ()
        {

        }
    }
}
