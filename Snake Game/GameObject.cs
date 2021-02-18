using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Game
{
    abstract class GameObject
    {
        public Position Pos;

        public GameObject()
        {

        }

        public GameObject(Position p)
        {
            Pos = p;
        }

        public GameObject (int x, int y)
        {
            Pos = new Position(x, y);
        }

        public void Move(int x, int y)
        {
            Pos.X += x;
            Pos.Y += y;
        }

        virtual public void Update()
        {

        }
    }

    interface IRenderable
    {
        public char Look { get; }
    }

    interface IMovable
    {
        public Direction Dir { get; set; }


    }
}

