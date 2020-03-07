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
            Rectangle rectangles = new Rectangle();

            try
            {
                // Prompt to user for X Postion
                string posX = UserPrompts.PromptForWidgetValue("Position X", rectangles.PositionX);

                // Validate the user input. If valid, stores the value in the object
                rectangles.PositionX = string.IsNullOrEmpty(posX) ? rectangles.PositionX : Validation.ValidatePositionValue(posX);

                string posY = UserPrompts.PromptForWidgetValue("Position Y", rectangles.PositionY);
                rectangles.PositionY = string.IsNullOrEmpty(posY) ? rectangles.PositionY : Validation.ValidatePositionValue(posY);

                string width = UserPrompts.PromptForWidgetValue("Width", rectangles.Width);
                rectangles.Width = string.IsNullOrEmpty(width) ? rectangles.Width : Validation.ValidateSizeValue(width);

                string height = UserPrompts.PromptForWidgetValue("Height", rectangles.Height);
                rectangles.Height = string.IsNullOrEmpty(height) ? rectangles.Height : Validation.ValidateSizeValue(height);

                // If all the user input is valid, pass the object on to have a BOM statement constructed
                return BOMBuilder(rectangles);
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
        /// <param name="rectangles">Rectangle object</param>
        /// <returns></returns>
        public string BOMBuilder(Rectangle rectangles)
            => $"Rectangle({rectangles.PositionX},{rectangles.PositionY}) width={rectangles.Width} height={rectangles.Height}";

    }
}