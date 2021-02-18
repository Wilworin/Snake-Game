using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Game
{
    class Food : GameObject, IRenderable
    {
        public char Look { get; } = '*';

        public Food ()
        {
            Random r = new Random();
            int x = r.Next(2, 80);
            int y = r.Next(4, 30);
            Pos = new Position(x, y);
        }

        //public Food(Position p)
        //{
        //    Pos = p;
        //}

        public Food(int x, int y):base (x,y)
        {
           // base(x, y);
        }

        public override void Update ()
        {

        }
    }
}
