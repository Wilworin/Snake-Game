using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Game
{
    /// <summary>
    /// Holds the world and all objects inside it.
    /// </summary>
    public class GameWorld
    {
        // I planned on having this list as private and thus created a method GetObjectList() that lets
        // other classes access it. I changed it to public for the sake of making the unit test 
        // GetObjectListTest() work.
        public List<GameObject> allObjects = new List<GameObject>();  // This holds all objects.

        public int width { get; set; }       // Holds the width (in chars) of the screen.
        public int height { get; set; }      // Holds the height (in chars) of the screen.
        public int score { get; set; } = 0;  // Keeps track of the player score.
        public DateTime gameTime { get; } = DateTime.Now; // Keeps track of how long the game has been running.
        private DateTime EatOrDieTimer { get; set; } = new DateTime(1900, 1, 1); // Used to keep track since the player last ate.

        public Player player { get; private set; } = null; // Holds the player.

        public GameWorld (int w, int h)
        {
            width = w;
            height = h;
        }


        /// <summary>
        /// Adds the linked GameObject into the list that holds all the GameObjects.
        /// </summary>
        /// <param name="obj"></param>
        public void AddToList (GameObject obj)
        {
            allObjects.Add(obj);
        }


        /// <summary>
        /// Returns a link to the list of all GameObjects.
        /// </summary>
        /// <returns></returns>
        public List<GameObject> GetObjectList ()
        {
            return allObjects;
        }
        

        /// <summary>
        /// Sets the player variable and adds to the gameobjects-list.
        /// </summary>
        /// <param name="p"></param>
        public void SetPlayer (Player p)
        {
            player = p;
            allObjects.Add(player);
        }


        /// <summary>
        /// This will call the Update method in all the GameObjects in the list allObjects.
        /// Then checks for collisions.
        /// </summary>
        public void Update()
        {
            foreach (GameObject obj in allObjects)
            {
                obj.Update();
            }
            DetectCollisions();
            if (GetEatOrDieTimer() < 0)
            {
                Program.SetGameOver();
            }
        }


        /// <summary>
        /// Detects collisions between player, tail and food.
        /// </summary>
        private void DetectCollisions ()
        {   // Note that the players collisions with the wall and it's own tail is done inside the Player class.
            for (int j = 0; j < allObjects.Count; j++)
            {
                if (allObjects[j] is Player) // If Player, check for collisions with Food.
                {
                    for (int i = allObjects.Count - 1; i >= 0; i--)
                    {
                        if (allObjects[i] is Food)
                        {
                            if (allObjects[i].Pos == allObjects[j].Pos)  // Collision with food detected.
                            {
                                allObjects.Remove(allObjects[i]);
                                AteFood();
                            }
                        }
                    }
                }
                else if (allObjects[j] is Food) // If food, check for collisions in the tail list.
                {
                    foreach (Tail t in player.GetTailList())
                    {
                        if (allObjects[j].Pos == t.Pos) // If collision with tail.
                        {
                            allObjects.Remove(allObjects[j]);
                            AteFood();
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Returns the elapsed game time in seconds.
        /// </summary>
        /// <returns></returns>
        public int GameSeconds()
        {
            return (int)Math.Floor((DateTime.Now - gameTime).TotalSeconds);
        }


        /// <summary>
        /// Resets the eat-or-die timer each time the player ate a food.
        /// </summary>
        public void ResetEatOrDieTimer()
        {
            EatOrDieTimer = DateTime.Now.AddSeconds(15);
        }


        /// <summary>
        /// Returns the eat-or-die timer rounded to 1 decimal. 
        /// </summary>
        /// <returns></returns>
        public double GetEatOrDieTimer()
        {
            if (EatOrDieTimer.Year != 1900)
            {
                return Math.Round((EatOrDieTimer - DateTime.Now).TotalSeconds, 1);
            }
            else
            {
                return 0.0;
            }
        }


        /// <summary>
        /// This handles if the player or tail has collided with food.
        /// </summary>
        private void AteFood()
        {
            player.AddTail();
            score++;
            AddToList(new Food());
            ResetEatOrDieTimer();
        }
    }
}
