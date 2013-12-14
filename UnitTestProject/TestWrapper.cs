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

        [TestMethod]
        public void TestInitCoordonates()
        {
            WrapperAlgo w = new WrapperAlgo();
            System.Collections.Generic.List<int> map = new System.Collections.Generic.List<int>();
            map.Add(2);
            map.Add(3);
            int size = 25;

            System.Collections.Generic.List<int> l = w.initCoordonates(map, size);

            Assert.AreEqual(l.Count, 2);
            Assert.IsTrue(l[0] < size);
            Assert.IsTrue(l[1] < size);
        }
    }
}
