using BOMApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BOMAppTests
{
    [TestClass]
    public class SizeInputValidationTests
    {
        [TestMethod]
        public void GreenPathTest()
        {
            // Arrange            
            string one = "1";

            // Act
            int validateOne = Validation.ValidateSizeValue(one);

            // Assert
            Assert.AreEqual(1, validateOne);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ExceptionThrownForZeroIntegerTest()
        {
            // Act
            string zero = "0";

            // Arrange
            Validation.ValidateSizeValue(zero);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ExceptionThrownForNegativeIntegerTest()
        {
            // Act
            string negative = "-1";
            
            // Arrange
            Validation.ValidateSizeValue(negative);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ExceptionThrownForNonIntegerTest()
        {
            // Act
            string nonInteger = "1.5";
        
            // Arrange
            Validation.ValidateSizeValue(nonInteger);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ExceptionThrownForWrittenIntegerTest()
        {
            // Act
            string written = "One";

            // Arrange
            Validation.ValidateSizeValue(written);
        }
    }
}
