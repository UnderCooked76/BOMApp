using System;

namespace BOMApp
{
    public class CircleProcessor : IProcessor<Circle>
    {
        /// <summary>
        /// Process for generating a Circle Widget Order
        /// </summary>
        /// <returns>string for a Circle Widget</returns>
        public string Process()
        {
            Circle circles = new Circle();

            try
            {
                // Prompt to user for X Postion
                string posX = UserPrompts.PromptForWidgetValue("Position X", circles.PositionX);

                // Validate the user input. If valid, stores the value in the object
                circles.PositionX = string.IsNullOrEmpty(posX) ? circles.PositionX : Validation.ValidatePositionValue(posX);

                string posY = UserPrompts.PromptForWidgetValue("Position Y", circles.PositionY);
                circles.PositionY = string.IsNullOrEmpty(posY) ? circles.PositionY : Validation.ValidatePositionValue(posY);

                string diameter = UserPrompts.PromptForWidgetValue("diameter", circles.Diameter);
                circles.Diameter = string.IsNullOrEmpty(diameter) ? circles.Diameter : Validation.ValidateSizeValue(diameter);

                // If all the user input is valid, pass the object on to have a BOM statement constructed
                return BOMBuilder(circles);
            }
            // Any problems are caught and an exception is thrown
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Takes a circle object and constructs a BOM statement
        /// </summary>
        /// <param name="circles">Circle object</param>
        /// <returns></returns>
        public string BOMBuilder(Circle circles)
            => $"Circle({circles.PositionX},{circles.PositionY}) size={circles.Diameter}";
    }
}
