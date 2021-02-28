using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    /// <summary>
    /// Holds all information about the Food.
    /// </summary>
    public class Food : GameObject, IRenderable
    {
        private DateTime spawnTimer; 
        public char Look { get; set; } = '*';

        public Food ()
        {
            RandomPos();
            spawnTimer = DateTime.Now;
            AnimateFood();
        }

        public Food(int x, int y):base (x,y)
        {
           
        }


        /// <summary>
        /// This is an async method that just makes the food blink. It really didn't have to be done async
        /// but it's very nice to just start it and then don't have to think about it anymore.
        /// </summary>
        private async void AnimateFood ()
        {
            while (true)
            {
                await Task.Delay(200);
                Look = '+';
                await Task.Delay(200);
                Look = '*';
            }
        }


        /// <summary>
        /// Checks if it has been 10 seconds since last moved and if so, sets a new position.
        /// </summary>
        public override void Update ()
        {
            if ((DateTime.Now - spawnTimer).TotalSeconds >= 10)
            {
                RandomPos();
                spawnTimer = DateTime.Now;
            }
        }


        /// <summary>
        /// Randomizes the position of the food.
        /// </summary>
        private void RandomPos ()
        {
            Random r = new Random();
            int x = r.Next(2, Program.ConsoleWidth - 1);
            int y = r.Next(4, Program.ConsoleHeight - 1);
            Pos = new Position(x, y);
        }
    }
}
