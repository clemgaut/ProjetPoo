using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TestPlayerCreation
    {
        [TestMethod]
        public void TestNationDemoCreation()
        {
            DemoGameBuilder demoBuilder = new DemoGameBuilder(ENation.GAUL, ENation.NAIN);

            Assert.AreNotEqual(demoBuilder.getPlayer1(), null);
            Assert.AreNotEqual(demoBuilder.getPlayer2(), null);

            Assert.AreEqual(demoBuilder.getPlayer1().getNation().getUnitsNumber(), 4);
            Assert.AreEqual(demoBuilder.getPlayer2().getNation().getUnitsNumber(), 4);

            foreach (Unit u in demoBuilder.getPlayer1().getNation().getUnits())
            {
                Assert.AreNotEqual(u, null);
                Assert.IsInstanceOfType(u, typeof(GaulUnit));
            }

            foreach (Unit u in demoBuilder.getPlayer2().getNation().getUnits())
            {
                Assert.AreNotEqual(u, null);
                Assert.IsInstanceOfType(u, typeof(NainUnit));
            }
        }
    }
}
