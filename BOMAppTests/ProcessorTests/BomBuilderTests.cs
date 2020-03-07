using BOMApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BOMAppTests
{
    [TestClass]
    public class BomBuilderTests
    {
        [TestMethod]
        public void RectangleBOMBuilderTest()
        {
            // Arrange
            Rectangle rectangle = new Rectangle()
            {
                PositionX = 20,
                PositionY = 30,
                Width = 40,
                Height = 50
            };
            string expectedBOM = "Rectangle(20,30) width=40 height=50";

            RectangleProcessor processor = new RectangleProcessor();

            // Act
            string returnedBOM = processor.BOMBuilder(rectangle);

            // Assert
            Assert.AreEqual(expectedBOM, returnedBOM);
        }

        [TestMethod]
        public void SquareBOMBuilderTest()
        {
            // Arrange
            Square square = new Square()
            {
                PositionX = 20,
                PositionY = 30,
                Width = 40,
            };
            string expectedBOM = "Square(20,30) size=40";

            SquareProcessor processor = new SquareProcessor();

            // Act
            string returnedBOM = processor.BOMBuilder(square);

            // Assert
            Assert.AreEqual(expectedBOM, returnedBOM);
        }

        [TestMethod]
        public void EllipseBOMBuilderTest()
        {
            // Arrange
            Ellipse ellipse = new Ellipse()
            {
                PositionX = 20,
                PositionY = 30,
                HorizontalDiameter = 40,
                VerticalDiameter = 50
            };
            string expectedBOM = "Ellipse(20,30) diameterH = 40 diameterV = 50";

            EllipseProcessor processor = new EllipseProcessor();

            // Act
            string returnedBOM = processor.BOMBuilder(ellipse);

            // Assert
            Assert.AreEqual(expectedBOM, returnedBOM);
        }

        [TestMethod]
        public void CircleBOMBuilderTest()
        {
            // Arrange
            Circle circle = new Circle()
            {
                PositionX = 20,
                PositionY = 30,
                Diameter = 40
            };
            string expectedBOM = "Circle(20,30) size=40";

            CircleProcessor processor = new CircleProcessor();

            // Act
            string returnedBOM = processor.BOMBuilder(circle);

            // Assert
            Assert.AreEqual(expectedBOM, returnedBOM);
        }

        [TestMethod]
        public void TextboxBOMBuilderTest()
        {
            // Arrange
            Textbox textbox = new Textbox()
            {
                PositionX = 20,
                PositionY = 30,
                Width = 40,
                Height = 50,
                Text = "This is a test"
            };
            string expectedBOM = "Textbox(20,30) width=40 height=50 text=\"This is a test\"";

            TextboxProcessor processor = new TextboxProcessor();

            // Act
            string returnedBOM = processor.BOMBuilder(textbox);

            // Assert
            Assert.AreEqual(expectedBOM, returnedBOM);
        }
    }
}
