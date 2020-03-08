using System;

namespace BOMApp
{
    public class RectangleProcessor : IProcessor<Rectangle>
    {
        /// <summary>
        /// Process for generating a Rectangle Widget Order
        /// </summary>
        /// <returns>string for a Rectangle Widget</returns>
        public string Process()
        {
            Rectangle rectangle = new Rectangle();

            Console.WriteLine("Please enter the values for your Rectangle Widget");
            try
            {
                // Prompt to user for X Postion
                string posX = UserPrompts.PromptForWidgetValue("Position X", rectangle.PositionX);

                // Validate the user input. If valid, stores the value in the object
                rectangle.PositionX = string.IsNullOrEmpty(posX) ? rectangle.PositionX : Validation.ValidatePositionValue(posX);

                string posY = UserPrompts.PromptForWidgetValue("Position Y", rectangle.PositionY);
                rectangle.PositionY = string.IsNullOrEmpty(posY) ? rectangle.PositionY : Validation.ValidatePositionValue(posY);

                string width = UserPrompts.PromptForWidgetValue("Width", rectangle.Width);
                rectangle.Width = string.IsNullOrEmpty(width) ? rectangle.Width : Validation.ValidateSizeValue(width);

                string height = UserPrompts.PromptForWidgetValue("Height", rectangle.Height);
                rectangle.Height = string.IsNullOrEmpty(height) ? rectangle.Height : Validation.ValidateSizeValue(height);

                // If all the user input is valid, pass the object on to have a BOM statement constructed
                return BOMBuilder(rectangle);
            }
            // Any problems are caught and an exception is thrown
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Takes a rectangle object and constructs a BOM statement
        /// </summary>
        /// <param name="rectangle">Rectangle object</param>
        /// <returns></returns>
        public string BOMBuilder(Rectangle rectangle)
            => $"Rectangle({rectangle.PositionX},{rectangle.PositionY}) width={rectangle.Width} height={rectangle.Height}";

    }
}