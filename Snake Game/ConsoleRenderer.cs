using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Game
{
    class ConsoleRenderer
    {
        private GameWorld world;
        public ConsoleRenderer(GameWorld gameWorld)
        {
            // TODO Konfigurera Console-fönstret enligt världens storlek

            world = gameWorld;
        }

        public void Render()
        {
            // TODO Rendera spelvärlden (och poängräkningen)

            // Använd Console.SetCursorPosition(int x, int y) and Console.Write(char)
        }
    }
}
