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
            DemoGameBuilder demoBuilder = new DemoGameBuilder();

            Assert.AreNotEqual(demoBuilder.getGame().getMap().getMap(), null);

            foreach (Box b in demoBuilder.getGame().getMap().getMap())
            {
                Assert.AreNotEqual(b, null);
                Assert.IsInstanceOfType(b, typeof(Box));
            }
        }
    }
}
