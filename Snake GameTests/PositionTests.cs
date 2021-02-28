using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snake_Game;
using System;
using System.Collections.Generic;
using System.Text;


// I have done 6 tests. Ofc I could have done more but you did say that "some" were enough since it was about
// us getting training writing them. :)
namespace Snake_Game.Tests
{
    [TestClass()]
    public class PositionTests
    {
        Position p1 = new Position(10, 20);
        Position p2 = new Position(10, 20);
        Position p3 = new Position(20, 20);

        [TestMethod()]
        public void EqualTest()
        {
            Assert.AreEqual(p1 == p2,true);
            Assert.AreEqual(p1 == p3, false);
        }

        [TestMethod()]
        public void NotEqualTest()
        {
            Assert.AreEqual(p1 != p2, false);
            Assert.AreEqual(p1 != p3, true);
        }

        [TestMethod()]
        public void PlusTest()
        {
            Assert.AreEqual((p1 + p2) == new Position(20, 40), true);
            Assert.AreEqual((p1 + p3) == new Position(30, 40), true);
        }

        [TestMethod()]
        public void MinusTest()
        {
            Assert.AreEqual((p1 - p2) == new Position(0, 0), true);
            Assert.AreEqual((p3 - p1) == new Position(10, 0), true);
        }

    }
}