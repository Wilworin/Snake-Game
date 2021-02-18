using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Game
{
    class Player : GameObject, IMovable, IRenderable
    {
        public char Look { get; set; } = 'Q';
        public Direction Dir { get; set; } = Direction.None;

        public Player ()
        {

        }

        public Player (int x, int y):base(x,y)
        {

        }

        override public void Update ()
        {
            switch (Dir)
            {
                case Direction.Up:
                    Pos.Y--;
                    break;
                case Direction.Down:
                    Pos.Y++;
                    break;
                case Direction.Left:
                    Pos.X--;
                    break;
                case Direction.Right:
                    Pos.X++;
                    break;
                default:
                    break;
            }
        }
    }
}
