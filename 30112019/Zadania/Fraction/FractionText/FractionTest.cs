using System;
using Rational;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FractionText
{
    [TestClass]
    public class FractionTest
    {
        [TestMethod]
        public void TestConstructors()
        {
            Fraction f = new Fraction(1, 2);

            Assert.AreEqual("1/2", f.ToString());

            f = new Fraction(2);

            Assert.AreEqual("2/1", f.ToString());

            f = new Fraction(0.7);
            Assert.AreEqual("7/10", f.ToString());

            f = new Fraction("1/2");
            Assert.AreEqual("1/2", f.ToString());
        }

        [TestMethod]
        public void TestAddFractions()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(1, 2);

            Fraction f3 = f1 + f2;

            Assert.AreEqual("1/1", f3.ToString());

        }

        [TestMethod]
        public void TestSubFractions()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(1, 4);

            Fraction f3 = f1 - f2;

            Assert.AreEqual("1/4", f3.ToString());
        }

        [TestMethod]
        public void TestMulFractions()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(1, 4);

            Fraction f3 = f1 * f2;

            Assert.AreEqual("1/8", f3.ToString());
        }

        [TestMethod]
        public void TestDivFractions()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(1, 4);

            Fraction f3 = f1 / f2;

            Assert.AreEqual("2/1", f3.ToString());
        }

        [TestMethod]
        public void TextGetDectimalValue()
        {
            Fraction f = new Fraction(0.7);

            Assert.AreEqual(0.7, f.GetDecimalValue());
        }


    }
}
