using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Game
{
    /// <summary>
    /// Handles the rendering of the world and similar things.
    /// </summary>
    class ConsoleRenderer
    {
        private GameWorld world;
        private List<Tail> tail;

        public ConsoleRenderer(GameWorld gameWorld)
        {
            world = gameWorld;
            tail = world.player.GetTailList();

            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.Write("SCORE: ");
            Console.SetCursorPosition(60, 0);
            Console.Write("GAME TIME: ");
            Console.SetCursorPosition(25, 0);
            Console.Write("EAT-OR-DIE TIMER: ");

            // It was much easier to just draw the wall once since we don't touch it again. Would be much more 
            // ineffective to add it to the gameobject-list and go through it every update for no reason at all.
            var wall = new Wall();
            wall.Update();

            // Adds the initial food.
            world.AddToList(new Food());
        }


        /// <summary>
        /// Goes through the list of objects and writes them all on the screen.
        /// Also types out the current score on the screen.
        /// </summary>
        public void Render()
        {
            foreach (GameObject obj in tail) // Draws the tail.
            {
                if (obj is IRenderable)
                {
                    Console.SetCursorPosition(obj.Pos.X, obj.Pos.Y);
                    IRenderable i = obj as IRenderable;
                    Console.Write(i.Look);
                }
            }

            foreach (GameObject obj in world.GetObjectList()) // Draws the player and the food.
            {
                if(obj is IRenderable)
                {
                    Console.SetCursorPosition(obj.Pos.X, obj.Pos.Y);
                    IRenderable i = obj as IRenderable;
                    Console.Write(i.Look);
                }
            }

            Console.SetCursorPosition(7, 0);
            Console.Write(world.score);  // Prints out score.
            Console.SetCursorPosition(71, 0);
            Console.Write(world.GameSeconds()); // Prints out game timer.
            Console.SetCursorPosition(43, 0);
            Console.Write(world.GetEatOrDieTimer()); // Prints out eat or die timer.
        }


        /// <summary>
        /// Goes through the list of objects and writes a space to blank them out.
        /// </summary>
        public void RenderBlank()
        {
            foreach (GameObject obj in world.GetObjectList())
            {
                if (obj is IRenderable)
                {
                    Console.SetCursorPosition(obj.Pos.X, obj.Pos.Y);
                    Console.Write(' ');
                }
            }
            foreach (GameObject obj in tail)
            {
                if (obj is IRenderable)
                {
                    Console.SetCursorPosition(obj.Pos.X, obj.Pos.Y);
                    Console.Write(' ');
                }
            }
        }
    }
}
