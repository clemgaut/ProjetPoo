using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject {
    [TestClass]
    public class TestUnitFactory {
        [TestMethod]
        public void TestGaulUnitCreation() {
            UnitFactory<GaulUnit> factoryGaul = new UnitFactory<GaulUnit>();

            List<Unit> l_u = (List<Unit>)factoryGaul.getUnits(1);

            Assert.IsInstanceOfType(l_u[0], typeof(GaulUnit));
        }

        [TestMethod]
        public void TestNainUnitCreation() {
            UnitFactory<NainUnit> factoryNain = new UnitFactory<NainUnit>();

            List<Unit> l_u = (List<Unit>) factoryNain.getUnits(1);

            Assert.IsInstanceOfType(l_u[0], typeof(NainUnit));
        }

        [TestMethod]
        public void TestVikingUnitCreation() {
            UnitFactory<VikingUnit> factoryViking = new UnitFactory<VikingUnit>();

            List<Unit> l_u = (List<Unit>) factoryViking.getUnits(1);

            Assert.IsInstanceOfType(l_u[0], typeof(VikingUnit));
        }
    }
}
