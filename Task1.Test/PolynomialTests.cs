using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.Library;

namespace Task1.Tests
{
    [TestClass]
    public class PolynomialTests
    {
        [TestMethod]
        public void GetValue_PolynomialOneTwoThreeCountVariableOne_SixReturned()
        {
            Polynomial polynom = new Polynomial(1, 2, 3);
            Assert.AreEqual(6, polynom.GetValue(1));
        }

        [TestMethod]
        public void Clone_PolynomialReferenceEqualsCloneOfPolynomial_FalseReturned()
        {
            Polynomial polynom = new Polynomial(1, 2, 3);
            Polynomial cloneOfPolynom = (Polynomial)polynom.Clone();
       
            Assert.AreEqual(false, ReferenceEquals(polynom, cloneOfPolynom));
        }

        [TestMethod]
        public void Clone_PolynomialEqualsCloneOfPolynomial_TrueReturned()
        {
            Polynomial polynom = new Polynomial(1, 2, 3);
            Polynomial cloneOfPolinom = (Polynomial)polynom.Clone();

            polynom.Equals(cloneOfPolinom);
        }

        [TestMethod]
        public void Equals_OneTwoThreeEqualsOneTwoThree_TrueReturned()
        {
            Polynomial a = new Polynomial(1, 2, 3);
            Polynomial b = new Polynomial(1, 2, 3);

            Assert.AreEqual(true, a.Equals(b));
        }

        [TestMethod]
        public void Equals_OneTwoThreeEqualsOneTwo_FalseReturned()
        {
            Polynomial a = new Polynomial(1, 2, 3);
            Polynomial b = new Polynomial(1, 2);

            Assert.AreEqual(false, a.Equals(b));
        }

        [TestMethod]
        public void Equals_OneTwoThreeEqualsOneThwoFour_FalseReturned()
        {
            Polynomial a = new Polynomial(1, 2, 3);
            Polynomial b = new Polynomial(1, 2, 4);

            Assert.AreEqual(false, a.Equals(b));
        }

        [TestMethod]
        public void OperatoPlus_123Plus456_579Returned()
        {
            Polynomial a = new Polynomial(1, 2, 3);
            Polynomial b = new Polynomial(4, 5, 6);
            Polynomial sum = a + b;

            Assert.AreEqual(true, sum.Equals(new Polynomial(5, 7, 9)));
        }

        [TestMethod]
        public void OperatoPlus_123Plus4567_5797Returned()
        {
            Polynomial a = new Polynomial(1, 2, 3);
            Polynomial b = new Polynomial(4, 5, 6, 7);
            Polynomial sum = a + b;

            Assert.AreEqual(true, sum.Equals(new Polynomial(5, 7, 9, 7)));
        }

        [TestMethod]
        public void OperatoMinus_123Minus4568_m3m3m3m8Returned()
        {
            Polynomial a = new Polynomial(1, 2, 3);
            Polynomial b = new Polynomial(4, 5, 6, 8);
            Polynomial sum = a - b;

            Assert.AreEqual(true, sum.Equals(new Polynomial(-3, -3, -3, -8)));
        }
    }
}
