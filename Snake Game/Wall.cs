using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Game
{
    /// <summary>
    /// Holds the information and draws the wall.
    /// </summary>
    class Wall : GameObject, IRenderable
    {
        public char Look { get; set; } = '█';


        /// <summary>
        /// Draws the walls around the world.
        /// </summary>
        /// <param name="world"></param>
        public override void Update()
        {
            //int width = world.width;
            //int height = world.height;
            int width = Program.ConsoleWidth;
            int height = Program.ConsoleHeight;

            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, 2);
                Console.Write(Look);
                Console.SetCursorPosition(i, height-1);
                Console.Write(Look);
            }
            for (int i = 3; i < height -1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(Look);
                Console.SetCursorPosition(width -1, i);
                Console.Write(Look);
            }
        }
    }

}
