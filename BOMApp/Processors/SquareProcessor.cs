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
            Square square = new Square();

            Console.WriteLine("Please enter the values for your Square Widget");
            try
            {
                // Prompt to user for X Postion
                string posX = UserPrompts.PromptForWidgetValue("Position X", square.PositionX);

                // Validate the user input. If valid, stores the value in the object
                square.PositionX = string.IsNullOrEmpty(posX) ? square.PositionX : Validation.ValidatePositionValue(posX);

                string posY = UserPrompts.PromptForWidgetValue("Position Y", square.PositionY);
                square.PositionY = string.IsNullOrEmpty(posY) ? square.PositionY : Validation.ValidatePositionValue(posY);

                string width = UserPrompts.PromptForWidgetValue("Width", square.Width);
                square.Width = string.IsNullOrEmpty(width) ? square.Width : Validation.ValidateSizeValue(width);

                // If all the user input is valid, pass the object on to have a BOM statement constructed
                return BOMBuilder(square);
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
        /// <param name="square">Square object</param>
        /// <returns></returns>
        public string BOMBuilder(Square square)
            => $"Square({square.PositionX},{square.PositionY}) size={square.Width}";
    }
}
