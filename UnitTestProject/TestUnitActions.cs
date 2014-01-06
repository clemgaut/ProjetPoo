using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject {
    [TestClass]
    public class TestUnitActions {
        private int[] lmap = 
        { (int)EBoxType.DESERT, (int)EBoxType.FOREST, (int)EBoxType.FOREST, (int)EBoxType.MOUNTAIN, (int)EBoxType.MOUNTAIN,
        (int)EBoxType.SEA, (int)EBoxType.LOWLAND, (int)EBoxType.MOUNTAIN, (int)EBoxType.FOREST, (int)EBoxType.DESERT,
        (int)EBoxType.SEA, (int)EBoxType.LOWLAND, (int)EBoxType.LOWLAND, (int)EBoxType.LOWLAND, (int)EBoxType.MOUNTAIN,
        (int)EBoxType.LOWLAND, (int)EBoxType.SEA, (int)EBoxType.FOREST, (int)EBoxType.DESERT, (int)EBoxType.SEA,
        (int)EBoxType.MOUNTAIN, (int)EBoxType.LOWLAND, (int)EBoxType.FOREST, (int)EBoxType.DESERT, (int)EBoxType.MOUNTAIN};

        private Game getDemoGame(ENation nation1, int line1, int column1, ENation nation2, int line2, int column2) {
            DemoGameBuilder demoBuilder = new DemoGameBuilder(nation1, nation2);
            Game game = demoBuilder.getGame();
            DemoMap map = new DemoMap();
            map.convertIntListToMap(new List<int>(lmap));
            game.setMap(map);
            game.getPlayer1().getNation().moveToNullPosition();
            game.getPlayer2().getNation().moveToNullPosition();
            game.getPlayer1().getNation().setInitBox(line1, column1, map);
            game.getPlayer2().getNation().setInitBox(line2, column2, map);

            return game;
        }
        
        [TestMethod]
        public void TestPointsNain() {
            Game game = getDemoGame(ENation.NAIN, 0, 0, ENation.GAUL, 4, 2);
            Map map = game.getMap();

            game.start();

            Assert.IsTrue(game.isPlayer1Active());
            Assert.IsTrue(game.getActivePlayer().getNation().getUnit(0).move(0, 1, map));

            game.nextStep();

            Assert.IsFalse(game.isPlayer1Active());

            Assert.AreEqual(game.getUnactivePlayer().getPoints(), 5);

            game.nextStep();
            Assert.IsTrue(game.isPlayer1Active());

            Assert.IsTrue(game.getActivePlayer().getNation().getUnit(0).move(1, 1, map));

            game.nextStep();

            Assert.IsFalse(game.isPlayer1Active());

            Assert.AreEqual(game.getUnactivePlayer().getPoints(), 8);
        }

        [TestMethod]
        public void TestMoveNotAllowedNain() {
            Game game = getDemoGame(ENation.NAIN, 4, 4, ENation.GAUL, 2, 2);
            Map map = game.getMap();

            game.start();
            Assert.IsTrue(game.isPlayer1Active());
            //Sea box
            Assert.IsFalse(game.getActivePlayer().getNation().getUnit(0).move(3, 4, map));
            //Too far box
            Assert.IsFalse(game.getActivePlayer().getNation().getUnit(0).move(4, 2, map));
            
            //One move, no more
            Assert.IsTrue(game.getActivePlayer().getNation().getUnit(0).move(4, 3, map));
            Assert.IsFalse(game.getActivePlayer().getNation().getUnit(0).move(4, 2, map));
        }

        [TestMethod]
        public void TestMoveAllowedNain() {
            Game game = getDemoGame(ENation.NAIN, 4, 4, ENation.GAUL, 2, 2);
            Map map = game.getMap();

            game.start();
            Assert.IsTrue(game.isPlayer1Active());

            //One normal move
            Assert.IsTrue(game.getActivePlayer().getNation().getUnit(0).move(4, 3, map));
            Assert.IsFalse(game.getActivePlayer().getNation().getUnit(0).hasMoves());

            //One mountain move
            Assert.IsTrue(game.getActivePlayer().getNation().getUnit(1).move(0, 4, map));
        }

        [TestMethod]
        public void TestPointsGaul() {
            Game game = getDemoGame(ENation.GAUL, 0, 1, ENation.NAIN, 4, 2);
            Map map = game.getMap();

            game.start();

            Assert.IsTrue(game.isPlayer1Active());
            Assert.IsTrue(game.getActivePlayer().getNation().getUnit(0).move(1, 1, map));

            game.nextStep();

            Assert.IsFalse(game.isPlayer1Active());

            Assert.AreEqual(game.getUnactivePlayer().getPoints(), 5);

            game.nextStep();
            Assert.IsTrue(game.isPlayer1Active());

            Assert.IsTrue(game.getActivePlayer().getNation().getUnit(0).move(1, 2, map));

            game.nextStep();

            Assert.IsFalse(game.isPlayer1Active());

            Assert.AreEqual(game.getUnactivePlayer().getPoints(), 8);
        }

        [TestMethod]
        public void TestMoveNotAllowedGaul() {
            Game game = getDemoGame(ENation.GAUL, 0, 0, ENation.NAIN, 2, 2);
            Map map = game.getMap();

            game.start();
            Assert.IsTrue(game.isPlayer1Active());
            //Sea box
            Assert.IsFalse(game.getActivePlayer().getNation().getUnit(0).move(1, 0, map));
            //Too far box
            Assert.IsFalse(game.getActivePlayer().getNation().getUnit(0).move(1, 1, map));

            //One move, no more
            Assert.IsTrue(game.getActivePlayer().getNation().getUnit(0).move(0, 1, map));
            Assert.IsFalse(game.getActivePlayer().getNation().getUnit(0).move(1, 1, map));
        }

        [TestMethod]
        public void TestMoveAllowedGaul() {
            Game game = getDemoGame(ENation.GAUL, 0, 1, ENation.NAIN, 2, 2);
            Map map = game.getMap();

            game.start();
            Assert.IsTrue(game.isPlayer1Active());

            //One normal move
            Assert.IsTrue(game.getActivePlayer().getNation().getUnit(0).move(0, 2, map));
            Assert.IsFalse(game.getActivePlayer().getNation().getUnit(0).hasMoves());

            //One lowland move
            Assert.IsTrue(game.getActivePlayer().getNation().getUnit(1).move(1, 1, map));
            Assert.IsFalse(game.getActivePlayer().getNation().getUnit(1).move(1, 2, map));
            Assert.IsTrue(game.getActivePlayer().getNation().getUnit(1).move(2, 1, map));
            Assert.IsFalse(game.getActivePlayer().getNation().getUnit(1).move(1, 1, map));
        }

        [TestMethod]
        public void TestPointsViking() {
            Game game = getDemoGame(ENation.VIKING, 2, 4, ENation.NAIN, 4, 2);
            Map map = game.getMap();

            game.start();

            Assert.IsTrue(game.isPlayer1Active());
            Assert.IsTrue(game.getActivePlayer().getNation().getUnit(0).move(3, 4, map));

            game.nextStep();

            Assert.IsFalse(game.isPlayer1Active());

            Assert.AreEqual(game.getUnactivePlayer().getPoints(), 6);

            game.nextStep();
            Assert.IsTrue(game.isPlayer1Active());

            Assert.IsTrue(game.getActivePlayer().getNation().getUnit(1).move(1, 4, map));

            game.nextStep();

            Assert.IsFalse(game.isPlayer1Active());

            Assert.AreEqual(game.getUnactivePlayer().getPoints(), 10);
        }

        [TestMethod]
        public void TestMoveNotAllowedViking() {
            Game game = getDemoGame(ENation.VIKING, 0, 0, ENation.NAIN, 2, 2);
            Map map = game.getMap();

            game.start();
            Assert.IsTrue(game.isPlayer1Active());
            //Too far box
            Assert.IsFalse(game.getActivePlayer().getNation().getUnit(0).move(1, 1, map));

            //One move, no more
            Assert.IsTrue(game.getActivePlayer().getNation().getUnit(0).move(0, 1, map));
            Assert.IsFalse(game.getActivePlayer().getNation().getUnit(0).move(1, 1, map));
        }

        [TestMethod]
        public void TestMoveAllowedViking() {
            Game game = getDemoGame(ENation.VIKING, 1, 1, ENation.NAIN, 2, 2);
            Map map = game.getMap();

            game.start();
            Assert.IsTrue(game.isPlayer1Active());

            //One normal move
            Assert.IsTrue(game.getActivePlayer().getNation().getUnit(0).move(1, 2, map));
            Assert.IsFalse(game.getActivePlayer().getNation().getUnit(0).hasMoves());

            //One sea move
            Assert.IsTrue(game.getActivePlayer().getNation().getUnit(1).move(0, 1, map));
            Assert.IsFalse(game.getActivePlayer().getNation().getUnit(1).move(0, 2, map));
        }

        [TestMethod]
        public void TestBasicFight() {
            NainUnit nain = new NainUnit();
            VikingUnit vik = new VikingUnit();

            vik.setLifePoints(0);

            Assert.IsTrue(nain.attack(vik));
        }

        [TestMethod]
        public void TestRandomFight() {
            int nainWin = 0;
            for (int i = 0; i < 10000; i++) {
                NainUnit nain = new NainUnit();
                VikingUnit vik = new VikingUnit();

                if (nain.attack(vik))
                    nainWin++;
            }
            //Can statistically fail sometimes rarely
            Assert.IsTrue(nainWin < 8000 && nainWin > 7000);
        }
    }
}
