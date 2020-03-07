using System;
using BOMApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BOMAppTests
{
    [TestClass]
    public class ErrorLoggingTests
    {
        [TestMethod]
        public void GenerateLogEntryTests()
        {
            // Act
            string error = "This is a test error";

            // Arrange
            string logEntry = ErrorLogging.GenerateLogEntry(error);

            // Assert
            Assert.IsTrue(logEntry.Contains(error));
            Assert.IsTrue(logEntry.Contains(Environment.UserName));
        }
    }
}
