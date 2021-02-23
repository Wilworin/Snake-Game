using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snake_Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Game.Tests
{
    [TestClass()]
    public class GameWorldTests
    {
        GameWorld world = new GameWorld(40, 20);

        [TestMethod()]
        public void GetObjectListTest()
        {
            Assert.AreEqual(world.GetObjectList(), world.allObjects);
        }

        [TestMethod()]
        public void AddToListTest()
        {
            var i1 = world.GetObjectList().Count;
            world.AddToList(new Food());
            var i2 = world.GetObjectList().Count;
            Assert.AreEqual(i1 + 1, i2);
        }

    }
}