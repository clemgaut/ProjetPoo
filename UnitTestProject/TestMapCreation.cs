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

            foreach (Box b in demoMap.getMap())
            {
                Assert.AreNotEqual(b, null);
                Assert.IsInstanceOfType(b, typeof(Box));
            }
        }
    }
}
