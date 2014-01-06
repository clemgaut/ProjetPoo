using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TestMapCreation
    {
        [TestMethod]
        public void TestDemoMapCreation()
        {
            DemoMap demoMap = new DemoMap();

            Assert.AreEqual(demoMap.Height, 5);
            Assert.AreEqual(demoMap.Width, 5);

            foreach (Box b in demoMap.getMap())
            {
                Assert.AreNotEqual(b, null);
                Assert.IsInstanceOfType(b, typeof(Box));
            }
        }

        [TestMethod]
        public void TestDemoGameBuilderMapCreation()
        {
            DemoGameBuilder demoBuilder = new DemoGameBuilder(ENation.GAUL, ENation.NAIN);

            Assert.AreNotEqual(demoBuilder.getGame().getMap().getMap(), null);

            Assert.AreEqual(demoBuilder.getGame().getMap().Height, 5);
            Assert.AreEqual(demoBuilder.getGame().getMap().Width, 5);

            foreach (Box b in demoBuilder.getGame().getMap().getMap())
            {
                Assert.AreNotEqual(b, null);
                Assert.IsInstanceOfType(b, typeof(Box));
            }
        }

        [TestMethod]
        public void TestSmallMapCreation() {
            SmallMap smallMap = new SmallMap();

            Assert.AreEqual(smallMap.Height, 10);
            Assert.AreEqual(smallMap.Width, 10);

            foreach (Box b in smallMap.getMap()) {
                Assert.AreNotEqual(b, null);
                Assert.IsInstanceOfType(b, typeof(Box));
            }
        }

        [TestMethod]
        public void TestSmallGameBuilderMapCreation() {
            SmallGameBuilder smallBuilder = new SmallGameBuilder(ENation.GAUL, ENation.NAIN);

            Assert.AreNotEqual(smallBuilder.getGame().getMap().getMap(), null);

            Assert.AreEqual(smallBuilder.getGame().getMap().Height, 10);
            Assert.AreEqual(smallBuilder.getGame().getMap().Width, 10);

            foreach (Box b in smallBuilder.getGame().getMap().getMap()) {
                Assert.AreNotEqual(b, null);
                Assert.IsInstanceOfType(b, typeof(Box));
            }
        }

        [TestMethod]
        public void TestNormalMapCreation() {
            NormalMap normalMap = new NormalMap();

            Assert.AreEqual(normalMap.Height, 15);
            Assert.AreEqual(normalMap.Width, 15);

            foreach (Box b in normalMap.getMap()) {
                Assert.AreNotEqual(b, null);
                Assert.IsInstanceOfType(b, typeof(Box));
            }
        }

        [TestMethod]
        public void TestNormalGameBuilderMapCreation() {
            NormalGameBuilder normalBuilder = new NormalGameBuilder(ENation.GAUL, ENation.VIKING);

            Assert.AreNotEqual(normalBuilder.getGame().getMap().getMap(), null);

            Assert.AreEqual(normalBuilder.getGame().getMap().Height, 15);
            Assert.AreEqual(normalBuilder.getGame().getMap().Width, 15);

            foreach (Box b in normalBuilder.getGame().getMap().getMap()) {
                Assert.AreNotEqual(b, null);
                Assert.IsInstanceOfType(b, typeof(Box));
            }
        }
    }
}
