using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Game
{
    /// <summary>
    /// Abstract class that all gameobjects builds upon.
    /// </summary>
    abstract public class GameObject
    {
        public Position Pos;

        // I created a few different constructors just incase but I don't use them all.
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


        /// <summary>
        /// Move the object.
        /// </summary>
        /// <param name="x">X-axis</param>
        /// <param name="y">Y-axis</param>
        public void Move(int x, int y)
        {
            Pos.X += x;
            Pos.Y += y;
        }

        virtual public void Update()
        {

        }
    }

    /// <summary>
    /// Is this renderable on the screen?
    /// </summary>
    interface IRenderable
    {
        char Look { get; }
    }


    /// <summary>
    /// Is this a movable object?
    /// </summary>
    interface IMovable
    {
        public Direction Dir { get; set; }
    }
}

