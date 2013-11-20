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
    }
}
