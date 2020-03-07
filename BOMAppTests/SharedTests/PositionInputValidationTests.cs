using BOMApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BOMAppTests
{
    [TestClass]
    public class PositionInputValidationTests
    {
        [TestMethod]
        public void GreenPathTest()
        {
            // Arrange            
            string one = "1";
            string zero = "0";

            // Act
            int validateOne = Validation.ValidatePositionValue(one);
            int validateZero = Validation.ValidatePositionValue(zero);

            // Assert
            Assert.AreEqual(1, validateOne);
            Assert.AreEqual(0, validateZero);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ExceptionThrownForNegativeIntegerTest()
        {
            // Act
            string negative = "-1";
            
            // Arrange
            Validation.ValidatePositionValue(negative);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ExceptionThrownForNonIntegerTest()
        {
            // Act
            string nonInteger = "1.5";
        
            // Arrange
            Validation.ValidatePositionValue(nonInteger);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ExceptionThrownForWrittenIntegerTest()
        {
            // Act
            string written = "One";

            // Arrange
            Validation.ValidatePositionValue(written);
        }
    }
}
