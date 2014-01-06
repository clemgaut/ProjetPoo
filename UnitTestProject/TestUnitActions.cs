using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject {
    [TestClass]
    public class TestUnitActions {
        private int[] lmap = 
        { (int)EBoxType.DESERT, (int)EBoxType.FOREST, (int)EBoxType.FOREST, (int)EBoxType.MOUTAIN, (int)EBoxType.MOUTAIN,
        (int)EBoxType.SEA, (int)EBoxType.LOWLAND, (int)EBoxType.FOREST, (int)EBoxType.MOUTAIN, (int)EBoxType.MOUTAIN,
        (int)EBoxType.SEA, (int)EBoxType.LOWLAND, (int)EBoxType.LOWLAND, (int)EBoxType.DESERT, (int)EBoxType.SEA,
        (int)EBoxType.LOWLAND, (int)EBoxType.SEA, (int)EBoxType.FOREST, (int)EBoxType.DESERT, (int)EBoxType.SEA,
        (int)EBoxType.MOUTAIN, (int)EBoxType.LOWLAND, (int)EBoxType.FOREST, (int)EBoxType.DESERT, (int)EBoxType.MOUTAIN};

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

            Assert.AreEqual(game.getActivePlayer().getNation().getUnit(0).GetType(), typeof(NainUnit));
            Assert.IsTrue(game.getActivePlayer().getNation().getUnit(0).move(0, 1, map));

            game.nextStep();

            Assert.AreEqual(game.getActivePlayer().getNation().getUnit(0).GetType(), typeof(GaulUnit));

            Assert.AreEqual(game.getUnactivePlayer().getPoints(), 5);

            game.nextStep();
            Assert.AreEqual(game.getActivePlayer().getNation().getUnit(0).GetType(), typeof(NainUnit));

            Assert.IsTrue(game.getActivePlayer().getNation().getUnit(0).move(1, 1, map));

            game.nextStep();

            Assert.AreEqual(game.getActivePlayer().getNation().getUnit(0).GetType(), typeof(GaulUnit));

            Assert.AreEqual(game.getUnactivePlayer().getPoints(), 8);
        }
    }
}
