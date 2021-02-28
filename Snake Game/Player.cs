using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Game
{
    /// <summary>
    /// Holds all information about to the player.
    /// </summary>
    public class Player : GameObject, IMovable, IRenderable
    {
        private List<Tail> tail = new List<Tail>();

        public char Look { get; } = 'Q';
        public Direction Dir { get; set; } = Direction.None;


        public Player (int x, int y):base(x,y)
        {
            //tail.Add(new Tail(Pos));

        }


        /// <summary>
        /// Updates the players Position according to the Direction.
        /// </summary>
        override public void Update ()
        {
            /* I'm changing so the game updates at different rates depending on if the player
             * is moving horisontally or vertically. This is done to create the illusion that the 
             * Snake moves at the same speed all the time. This is all due to the console
             * letters being differently sized when it comes to height and width. */

            const int verticalFrameRate = 10;
            const int horizontalFrameRate = 16;

            if (Dir != Direction.None)
            {
                tail.Add(new Tail(Pos.X, Pos.Y));
                tail.RemoveAt(0);
            }

            switch (Dir)
            {
                case Direction.Up:
                    Pos.Y--;
                    Program.ChangeFrameRate(verticalFrameRate);
                    break;
                case Direction.Down:
                    Pos.Y++;
                    Program.ChangeFrameRate(verticalFrameRate);
                    break;
                case Direction.Left:
                    Pos.X--;
                    Program.ChangeFrameRate(horizontalFrameRate);
                    break;
                case Direction.Right:
                    Pos.X++;
                    Program.ChangeFrameRate(horizontalFrameRate);
                    break;
                default:
                    break;
            }
            CheckBorder(); // Checks if the snake has ran into the wall and then calls Game Over.
            CheckCollideWithTail();
        }


        /// <summary>
        /// Returns a reference to the tail list so the renderer easily can go through it.
        /// </summary>
        /// <returns></returns>
        public List<Tail> GetTailList ()
        {
            return tail;
        }


        /// <summary>
        /// Adds an extra tail at the players position.
        /// </summary>
        public void AddTail()
        {
            tail.Add(new Tail(Pos.X, Pos.Y));
        }


        /// <summary>
        /// Checks if the player ran into the wall and if so, calls Game Over.
        /// </summary>
        private void CheckBorder ()
        {
            if (Pos.Y <= 2 || Pos.Y >= Program.ConsoleHeight - 1 || Pos.X < 1 || Pos.X >= Program.ConsoleWidth - 1)
            {
                Program.SetGameOver();
            }
        }


        /// <summary>
        /// Checks if the player has collided with his own tail and if so, calls Game Over.
        /// </summary>
        private void CheckCollideWithTail ()
        {
            foreach (Tail t in tail)
            {
                if (Pos == t.Pos)
                {
                    Program.SetGameOver();
                }
            }
        }

   }
}
