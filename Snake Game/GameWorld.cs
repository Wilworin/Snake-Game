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
        /// This will call the Update method in all the GameObjects in the list allObjects.
        /// </summary>
        public void Update()
        {
            foreach (GameObject obj in allObjects)
            {
                obj.Update();
            }

            // Collision Detection
            for (int j = 0; j < allObjects.Count; j++)
            {
                if(allObjects[j] is Player)
                {
                    for (int i = allObjects.Count -1; i >= 0; i--)
                    {
                        if (allObjects[i] is Food)  // Collision with food detected.
                        {
                            if (allObjects[i].Pos == allObjects[j].Pos)
                            {
                                allObjects.Remove(allObjects[i]);
                                score++;
                                AddToList(new Food());
                            }
                        }
                    }
                }
            }
        }
    }
}
