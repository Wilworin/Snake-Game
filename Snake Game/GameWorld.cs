using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Game
{
    class GameWorld
    {
        private List<GameObject> allObjects = new List<GameObject>();

        public int width { get; set; }
        public int height { get; set; }
        public int score { get; set; }


        public void AddToList (GameObject obj)
        {
            allObjects.Add(obj);
        }
        
        public void Update()
        {
            foreach (GameObject obj in allObjects)
            {
                obj.Update();
            }
        }
    }
}
