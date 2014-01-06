using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject {
    [TestClass]
    public class TestGame {
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
        public void TestTieGame() {
            Game game = getDemoGame(ENation.NAIN, 0, 0, ENation.GAUL, 4, 2);
            Map map = game.getMap();

            game.start();

            for (int i = 0; i < 4; i++) {
                game.nextStep();
                game.nextStep();
            }

            Assert.IsFalse(game.checkEndfOfGame());
            game.nextStep();
            Assert.IsFalse(game.checkEndfOfGame());
            game.nextStep();
            Assert.IsTrue(game.checkEndfOfGame());
            Assert.IsNull(game.getWinner());
        }

        [TestMethod]
        public void TestWinNoFightGame() {
            Game game = getDemoGame(ENation.NAIN, 0, 1, ENation.GAUL, 4, 2);
            Map map = game.getMap();

            game.start();

            for (int i = 0; i < 5; i++) {
                game.nextStep();
                game.nextStep();
            }
            Assert.IsTrue(game.checkEndfOfGame());
            Assert.AreEqual(game.getWinner(), game.getPlayer1());
        }

        [TestMethod]
        public void TestWinP2NoFightGame() {
            Game game = getDemoGame(ENation.NAIN, 1, 1, ENation.GAUL, 4, 2);
            Map map = game.getMap();

            game.start();

            for (int i = 0; i < 5; i++) {
                game.nextStep();
                game.nextStep();
            }
            Assert.IsTrue(game.checkEndfOfGame());
            Assert.AreEqual(game.getWinner(), game.getPlayer2());
        }

        [TestMethod]
        public void TestWinFightGame() {
            Game game = getDemoGame(ENation.NAIN, 0, 0, ENation.GAUL, 4, 2);
            Map map = game.getMap();

            game.start();

            Assert.IsFalse(game.checkEndfOfGame());

            foreach (Unit u in game.getUnactivePlayer().getNation().getUnits())
                u.setLifePoints(0);
            game.getUnactivePlayer().getNation().deleteDeadUnits();

            game.nextStep();

            Assert.IsTrue(game.checkEndfOfGame());
            Assert.AreEqual(game.getWinner(), game.getPlayer1());
        }

        [TestMethod]
        public void TestWinPlayer2FightGame() {
            Game game = getDemoGame(ENation.NAIN, 0, 0, ENation.GAUL, 4, 2);
            Map map = game.getMap();

            game.start();

            Assert.IsFalse(game.checkEndfOfGame());

            foreach (Unit u in game.getActivePlayer().getNation().getUnits())
                u.setLifePoints(0);
            game.getActivePlayer().getNation().deleteDeadUnits();

            game.nextStep();

            Assert.IsTrue(game.checkEndfOfGame());
            Assert.AreEqual(game.getWinner(), game.getPlayer2());
        }

        [TestMethod]
        public void TestBestDefensiveUnit() {
            Game game = getDemoGame(ENation.NAIN, 0, 0, ENation.GAUL, 4, 2);
            Map map = game.getMap();

            game.start();

            Assert.IsNull(game.getBestDefensiveUnit(0, 0));
            Assert.IsNull(game.getBestDefensiveUnit(0, 1));

            for (int i = 1; i < game.getUnactivePlayer().getNation().getUnitsNumber(); i++)
                game.getUnactivePlayer().getNation().getUnit(i).setLifePoints(0);

            Assert.AreEqual(game.getUnactivePlayer().getNation().getUnit(0), game.getBestDefensiveUnit(4, 2));
        }
    }
}
