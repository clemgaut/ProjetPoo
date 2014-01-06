using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject {
    [TestClass]
    public class TestGameBuilder {
        [TestMethod]
        public void TestDemoGameBuilder() {
            DemoGameBuilder demoGameBuilder = new DemoGameBuilder(ENation.NAIN, ENation.VIKING);

            Assert.AreEqual(demoGameBuilder.getGame().getSteps(), 5);
        }

        [TestMethod]
        public void TestSmallGameBuilder() {
            SmallGameBuilder smallGameBuilder = new SmallGameBuilder(ENation.NAIN, ENation.VIKING);

            Assert.AreEqual(smallGameBuilder.getGame().getSteps(), 20);
        }

        [TestMethod]
        public void TestNormalGameBuilder() {
            NormalGameBuilder normalGameBuilder = new NormalGameBuilder(ENation.NAIN, ENation.VIKING);

            Assert.AreEqual(normalGameBuilder.getGame().getSteps(), 30);
        }
    }
}
