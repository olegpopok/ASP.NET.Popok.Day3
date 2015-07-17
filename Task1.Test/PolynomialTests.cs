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
        public void Clone_PolynomialReferenceEqualsPolynomialClone_FalseReturned()
        {
            Polynomial polynom = new Polynomial(1, 2, 3);
            Polynomial cloneOfPolynom = (Polynomial)polynom.Clone();
       
            Assert.AreEqual(false, ReferenceEquals(polynom, cloneOfPolynom));
        }

        
        
    }
}
