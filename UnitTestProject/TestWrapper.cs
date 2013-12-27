using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wrapper;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestConnectWrapper
    {
        [TestMethod]
        public void TestMethodWrapperCreation()
        {
            WrapperAlgo w = new WrapperAlgo();
            Assert.AreNotEqual(w, null);
        }

        [TestMethod]
        public void TestMethodWrapperBasicUse()
        {
            WrapperAlgo w = new WrapperAlgo();
            Assert.AreNotEqual(w, null);
            Assert.AreEqual(10, w.fTest(10));
        }

        [TestMethod]
        public void TestBasicMapGeneration()
        {
            WrapperAlgo w = new WrapperAlgo();
            int types = 6;
            int size = 10;

            System.Collections.Generic.List<int> l = w.mapGeneration(size, types);

            Assert.AreEqual(size, l.Count);

            foreach(int n in l)
            {
                Assert.IsTrue(n >= 1 && n <= types);
            }
        }

        [TestMethod]
        public void TestInitCoordonates()
        {
            WrapperAlgo w = new WrapperAlgo();
            System.Collections.Generic.List<int> map = new System.Collections.Generic.List<int>();
            map.Add(2);
            map.Add(3);
            int size = 25;

            System.Collections.Generic.List<int> l = w.initCoordonates(map, size);

            Assert.AreEqual(l.Count, 2);
            Assert.IsTrue(l[0] < size);
            Assert.IsTrue(l[1] < size);
        }

        [TestMethod]
        public void TestPossibleMoves() {
            GameBuilder builder = new NormalGameBuilder(ENation.GAUL, ENation.NAIN);
            Game g = builder.getGame();
            g.start();

            WrapperAlgo w = new WrapperAlgo();
            ENation nat = g.getActivePlayer().getNation().nationType;
            int pos = g.getActivePlayer().getNation().getUnit(0).getLine() * g.getMap().Width + g.getActivePlayer().getNation().getUnit(0).getColumn();

            System.Collections.Generic.List<int> l = w.possibleMoves(g.getMap().convertMapToIntList(), (int) nat, pos, g.getOpponentUnitsPositions());

            Assert.AreEqual(l.Count % 2, 0);

        }
    }
}
