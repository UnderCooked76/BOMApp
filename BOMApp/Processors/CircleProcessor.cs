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
            Circle circle = new Circle();

            Console.WriteLine("Please enter the values for your Circle Widget");
            try
            {
                // Prompt to user for X Postion
                string posX = UserPrompts.PromptForWidgetValue("Position X", circle.PositionX);

                // Validate the user input. If valid, stores the value in the object
                circle.PositionX = string.IsNullOrEmpty(posX) ? circle.PositionX : Validation.ValidatePositionValue(posX);

                string posY = UserPrompts.PromptForWidgetValue("Position Y", circle.PositionY);
                circle.PositionY = string.IsNullOrEmpty(posY) ? circle.PositionY : Validation.ValidatePositionValue(posY);

                string diameter = UserPrompts.PromptForWidgetValue("diameter", circle.Diameter);
                circle.Diameter = string.IsNullOrEmpty(diameter) ? circle.Diameter : Validation.ValidateSizeValue(diameter);

                // If all the user input is valid, pass the object on to have a BOM statement constructed
                return BOMBuilder(circle);
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
        /// <param name="circle">Circle object</param>
        /// <returns></returns>
        public string BOMBuilder(Circle circle)
            => $"Circle({circle.PositionX},{circle.PositionY}) size={circle.Diameter}";
    }
}
