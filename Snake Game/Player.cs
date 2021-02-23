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
        public char Look { get; } = 'Q';
        public Direction Dir { get; set; } = Direction.None;


        public Player (int x, int y):base(x,y)
        {

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

            // The checks are to ensure that the player can't go outside the wall.
            switch (Dir)
            {
                case Direction.Up:
                    if (Pos.Y > 3)
                    {
                        Pos.Y--;
                        Program.ChangeFrameRate(verticalFrameRate);
                    }
                    break;
                case Direction.Down:
                    if (Pos.Y < Program.ConsoleHeight -2)
                    {
                        Pos.Y++;
                        Program.ChangeFrameRate(verticalFrameRate);
                    }
                    break;
                case Direction.Left:
                    if (Pos.X > 1)
                    {
                        Pos.X--;
                        Program.ChangeFrameRate(horizontalFrameRate);
                    }
                    break;
                case Direction.Right:
                    if (Pos.X < Program.ConsoleWidth -2)
                    {
                        Pos.X++;
                        Program.ChangeFrameRate(horizontalFrameRate);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
