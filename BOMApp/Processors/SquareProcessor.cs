using System;

namespace BOMApp
{
    public class SquareProcessor : IProcessor<Square>
    {
        /// <summary>
        /// Process for generating a Square Widget Order
        /// </summary>
        /// <returns>string for a Square Widget</returns>
        public string Process()
        {
            Square squares = new Square();

            try
            {
                // Prompt to user for X Postion
                string posX = UserPrompts.PromptForWidgetValue("Position X", squares.PositionX);

                // Validate the user input. If valid, stores the value in the object
                squares.PositionX = string.IsNullOrEmpty(posX) ? squares.PositionX : Validation.ValidatePositionValue(posX);

                string posY = UserPrompts.PromptForWidgetValue("Position Y", squares.PositionY);
                squares.PositionY = string.IsNullOrEmpty(posY) ? squares.PositionY : Validation.ValidatePositionValue(posY);

                string width = UserPrompts.PromptForWidgetValue("Width", squares.Width);
                squares.Width = string.IsNullOrEmpty(width) ? squares.Width : Validation.ValidateSizeValue(width);

                // If all the user input is valid, pass the object on to have a BOM statement constructed
                return BOMBuilder(squares);
            }
            // Any problems are caught and an exception is thrown
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Takes a square object and constructs a BOM statement
        /// </summary>
        /// <param name="squares">Square object</param>
        /// <returns></returns>
        public string BOMBuilder(Square squares)
            => $"Square({squares.PositionX},{squares.PositionY}) size={squares.Width}";
    }
}
