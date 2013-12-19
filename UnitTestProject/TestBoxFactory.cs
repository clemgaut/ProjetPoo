using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject {
    [TestClass]
    public class TestBoxFactory {
        BoxFactory factory = new BoxFactory();

        [TestMethod]
        public void TestDesertBoxCreation() {
            Box desertBox = factory.getBox(EBoxType.DESERT);
            Assert.IsInstanceOfType(desertBox, typeof(DesertBox));
        }

        [TestMethod]
        public void TestForestBoxCreation() {
            Box forestBox = factory.getBox(EBoxType.FOREST);
            Assert.IsInstanceOfType(forestBox, typeof(ForestBox));
        }

        [TestMethod]
        public void TestLowlandBoxCreation() {
            Box lowlandBox = factory.getBox(EBoxType.LOWLAND);
            Assert.IsInstanceOfType(lowlandBox, typeof(LowlandBox));
        }

        [TestMethod]
        public void TestMountainBoxCreation() {
            Box mountainBox = factory.getBox(EBoxType.MOUTAIN);
            Assert.IsInstanceOfType(mountainBox, typeof(MountainBox));
        }

        [TestMethod]
        public void TestSeaBoxCreation() {
            Box seaBox = factory.getBox(EBoxType.SEA);
            Assert.IsInstanceOfType(seaBox, typeof(SeaBox));
        }
    }
}
