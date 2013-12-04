using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wrapper;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestConnectWrapper
    {
        [TestMethod]
        public void TestMethodWrapperCreation()
        {
            WrapperAlgo w = new WrapperAlgo();
            Assert.AreNotEqual(w, null);
        }

        [TestMethod]
        public void TestMethodWrapperBasicUse()
        {
            WrapperAlgo w = new WrapperAlgo();
            Assert.AreNotEqual(w, null);
            Assert.AreEqual(10, w.fTest(10));
        }

        [TestMethod]
        public void TestBasicMapGeneration()
        {
            WrapperAlgo w = new WrapperAlgo();
            int types = 6;
            int size = 10;

            System.Collections.Generic.List<int> l = w.mapGeneration(size, types);

            Assert.AreEqual(size, l.Count);

            foreach(int n in l)
            {
                Assert.IsTrue(n >= 1 && n <= types);
            }
        }
    }
}
