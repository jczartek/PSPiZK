using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Umk;

namespace TestyJednostkoweSilni
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, ObliczanieSilni.Oblicz(0));
            Assert.AreEqual(1, ObliczanieSilni.Oblicz(1));
            Assert.AreEqual(2, ObliczanieSilni.Oblicz(2));
            Assert.AreEqual(6, ObliczanieSilni.Oblicz(3));
            Assert.AreEqual(24, ObliczanieSilni.Oblicz(4));
        }
    }
}
