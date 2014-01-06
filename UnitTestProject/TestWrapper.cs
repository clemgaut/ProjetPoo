using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wrapper;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestConnectWrapper
    {
        private int[] lmap = 
        { (int)EBoxType.DESERT, (int)EBoxType.FOREST, (int)EBoxType.FOREST, (int)EBoxType.MOUNTAIN, (int)EBoxType.MOUNTAIN,
        (int)EBoxType.SEA, (int)EBoxType.LOWLAND, (int)EBoxType.DESERT, (int)EBoxType.FOREST, (int)EBoxType.DESERT,
        (int)EBoxType.SEA, (int)EBoxType.LOWLAND, (int)EBoxType.LOWLAND, (int)EBoxType.LOWLAND, (int)EBoxType.MOUNTAIN,
        (int)EBoxType.LOWLAND, (int)EBoxType.SEA, (int)EBoxType.FOREST, (int)EBoxType.DESERT, (int)EBoxType.SEA,
        (int)EBoxType.MOUNTAIN, (int)EBoxType.LOWLAND, (int)EBoxType.MOUNTAIN, (int)EBoxType.SEA, (int)EBoxType.FOREST};

        private Game getDemoGame(ENation nation1, int line1, int column1, ENation nation2, int line2, int column2) {
            DemoGameBuilder demoBuilder = new DemoGameBuilder(nation1, nation2);
            Game game = demoBuilder.getGame();
            DemoMap map = new DemoMap();
            map.convertIntListToMap(new System.Collections.Generic.List<int>(lmap));
            game.setMap(map);
            game.getPlayer1().getNation().moveToNullPosition();
            game.getPlayer2().getNation().moveToNullPosition();
            game.getPlayer1().getNation().setInitBox(line1, column1, map);
            game.getPlayer2().getNation().setInitBox(line2, column2, map);

            return game;
        }

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
        public void TestNoPossibleMoves() {
            Game game = getDemoGame(ENation.GAUL, 4, 4, ENation.NAIN, 4, 2);
            Map map = game.getMap();

            game.start();

            WrapperAlgo w = new WrapperAlgo();
            ENation nat = game.getActivePlayer().getNation().nationType;
            int pos = game.getActivePlayer().getNation().getUnit(0).getLine() * game.getMap().Width + game.getActivePlayer().getNation().getUnit(0).getColumn();

            System.Collections.Generic.List<int> l = w.possibleMoves(game.getMap().convertMapToIntList(), (int) nat, pos, game.getOpponentUnitsPositions());

            Assert.AreEqual(l.Count, 0);
        }

        [TestMethod]
        public void TestNainPossibleMoves() {
            Game game = getDemoGame(ENation.NAIN, 0, 0, ENation.GAUL, 4, 2);
            Map map = game.getMap();

            game.start();

            WrapperAlgo w = new WrapperAlgo();
            ENation nat = game.getActivePlayer().getNation().nationType;
            int pos = game.getActivePlayer().getNation().getUnit(0).getLine() * game.getMap().Width + game.getActivePlayer().getNation().getUnit(0).getColumn();

            System.Collections.Generic.List<int> l = w.possibleMoves(game.getMap().convertMapToIntList(), (int) nat, pos, game.getOpponentUnitsPositions());

            Assert.AreEqual(l.Count, 2);
            Assert.AreEqual(l[0], 0);
            Assert.AreEqual(l[1], 1);

        }

        [TestMethod]
        public void TestNainMountainPossibleMoves() {
            Game game = getDemoGame(ENation.NAIN, 4, 0, ENation.GAUL, 4, 2);
            Map map = game.getMap();

            game.start();

            WrapperAlgo w = new WrapperAlgo();
            ENation nat = game.getActivePlayer().getNation().nationType;
            int pos = game.getActivePlayer().getNation().getUnit(0).getLine() * game.getMap().Width + game.getActivePlayer().getNation().getUnit(0).getColumn();

            System.Collections.Generic.List<int> l = w.possibleMoves(game.getMap().convertMapToIntList(), (int) nat, pos, game.getOpponentUnitsPositions());

            Assert.AreEqual(l.Count, 12);
            Assert.AreEqual(l[0], 0);
            Assert.AreEqual(l[1], 3);

            Assert.AreEqual(l[2], 0);
            Assert.AreEqual(l[3], 4);

            Assert.AreEqual(l[4], 2);
            Assert.AreEqual(l[5], 4);

            Assert.AreEqual(l[6], 3);
            Assert.AreEqual(l[7], 0);

            Assert.AreEqual(l[8], 4);
            Assert.AreEqual(l[9], 1);

            Assert.AreEqual(l[10], 4);
            Assert.AreEqual(l[11], 2);

        }

        [TestMethod]
        public void TestGaulPossibleMoves() {
            Game game = getDemoGame(ENation.GAUL, 3, 2, ENation.NAIN, 4, 2);
            Map map = game.getMap();

            game.start();

            WrapperAlgo w = new WrapperAlgo();
            ENation nat = game.getActivePlayer().getNation().nationType;
            int pos = game.getActivePlayer().getNation().getUnit(0).getLine() * game.getMap().Width + game.getActivePlayer().getNation().getUnit(0).getColumn();

            System.Collections.Generic.List<int> l = w.possibleMoves(game.getMap().convertMapToIntList(), (int) nat, pos, game.getOpponentUnitsPositions());

            Assert.AreEqual(l.Count, 6);
            Assert.AreEqual(l[0], 2);
            Assert.AreEqual(l[1], 2);

            Assert.AreEqual(l[2], 3);
            Assert.AreEqual(l[3], 3);

            Assert.AreEqual(l[4], 4);
            Assert.AreEqual(l[5], 2);

        }

        [TestMethod]
        public void TestVikingPossibleMoves() {
            Game game = getDemoGame(ENation.VIKING, 3, 2, ENation.NAIN, 4, 2);
            Map map = game.getMap();

            game.start();

            WrapperAlgo w = new WrapperAlgo();
            ENation nat = game.getActivePlayer().getNation().nationType;
            int pos = game.getActivePlayer().getNation().getUnit(0).getLine() * game.getMap().Width + game.getActivePlayer().getNation().getUnit(0).getColumn();

            System.Collections.Generic.List<int> l = w.possibleMoves(game.getMap().convertMapToIntList(), (int) nat, pos, game.getOpponentUnitsPositions());

            Assert.AreEqual(l.Count, 8);
            Assert.AreEqual(l[0], 2);
            Assert.AreEqual(l[1], 2);

            Assert.AreEqual(l[2], 3);
            Assert.AreEqual(l[3], 1);
            
            Assert.AreEqual(l[4], 3);
            Assert.AreEqual(l[5], 3);

            Assert.AreEqual(l[6], 4);
            Assert.AreEqual(l[7], 2);

        }
    }
}
