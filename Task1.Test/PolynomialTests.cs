using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.Library;

namespace Task1.Tests
{
    [TestClass]
    public class PolynomialTests
    {
        #region GetValueTests
        [TestMethod]
        public void GetValue_Polynomial123AtVariable1_SixReturned()
        {
            Polynomial polynom = new Polynomial(1,2,3);
            Assert.AreEqual(6, polynom.GetValue(1));
        }

        [TestMethod]
        public void GetValue_Polynomial123AtVariable2_SixReturned()
        {
            Polynomial polynom = new Polynomial(1, 2, 3);
            Assert.AreEqual(17, polynom.GetValue(2));
        }
        #endregion

        #region CloneTests
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
        #endregion

        #region EqualsTests
        [TestMethod]
        public void Equals_Reflexive_TrueReturned()
        {
            Polynomial x = new Polynomial(1, 2, 3);
            Assert.AreEqual(true, x.Equals(x));
        }   

        [TestMethod]
        public void Equals_Symmetric_TrueReturned()
        {
            Polynomial x = new Polynomial(1, 2, 3);
            Polynomial y = new Polynomial(1, 2);
            Assert.AreEqual(x.Equals(y), y.Equals(x));
        }

        [TestMethod]
        public void Equals_123Equals124_FalseReturned()
        {
            Polynomial a = new Polynomial(1, 2, 3);
            Polynomial b = new Polynomial(1, 2, 4);

            Assert.AreEqual(false, a.Equals(b));
        }

        [TestMethod]
        public void Equals_123Equals123_TrueReturned()
        {
            Polynomial a = null;
            Polynomial b = null;

            Assert.AreEqual(true, a == b);
        }
        #endregion

        #region Operator+Tests
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
        #endregion

        #region Operator-Tests
        [TestMethod]
        public void OperatoMinus_123Minus4568_m3m3m3m8Returned()
        {
            Polynomial a = new Polynomial(1, 2, 3);
            Polynomial b = new Polynomial(4, 5, 6, 8);
            Polynomial remainde = a - b;

            Assert.AreEqual(true, remainde.Equals(new Polynomial(-3, -3, -3, -8)));
        }
        #endregion

        #region Operator*Tests
        [TestMethod]
        public void OperatoMul_123Mul2_246Returned()
        {
            Polynomial a = new Polynomial(1, 2, 3);
            double b = 2;
            Polynomial product = b * a;

            Assert.AreEqual(true, product.Equals(new Polynomial(2,4,6)));
        }
        #endregion

        #region ToStringTests
        [TestMethod]
        public void ToString_Polynom123ToString_1Spase2Spase3SpaseReturned()
        {
            Polynomial polynom = new Polynomial(1, 2, 3);
            Assert.AreEqual("1 2 3 ", polynom.ToString());
        }
        #endregion

        public void GetHashCode_GhcEqualGhc_TrueReturned()
        {
            Polynomial a = new Polynomial(1, 2, 3, 4);
            Polynomial b = new Polynomial(1, 2, 3, 4);
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }
    }
}
