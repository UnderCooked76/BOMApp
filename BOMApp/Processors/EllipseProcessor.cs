using System;

namespace BOMApp
{
    public class EllipseProcessor : IProcessor<Ellipse>
    {
        /// <summary>
        /// Process for generating a Ellipse Widget Order
        /// </summary>
        /// <returns>string for a Ellipse Widget</returns>
        public string Process()
        {
            Ellipse ellipse = new Ellipse();

            Console.WriteLine("Please enter the values for your Ellipse Widget");
            try
            {
                // Prompt to user for X Postion
                string posX = UserPrompts.PromptForWidgetValue("Position X", ellipse.PositionX);

                // Validate the user input. If valid, stores the value in the object
                ellipse.PositionX = string.IsNullOrEmpty(posX) ? ellipse.PositionX : Validation.ValidatePositionValue(posX);

                string posY = UserPrompts.PromptForWidgetValue("Position Y", ellipse.PositionY);
                ellipse.PositionY = string.IsNullOrEmpty(posY) ? ellipse.PositionY : Validation.ValidatePositionValue(posY);

                string hDiameter = UserPrompts.PromptForWidgetValue("Horizontal Diameter", ellipse.HorizontalDiameter);
                ellipse.HorizontalDiameter = string.IsNullOrEmpty(hDiameter) ? ellipse.HorizontalDiameter : Validation.ValidateSizeValue(hDiameter);

                string vDiameter = UserPrompts.PromptForWidgetValue("Vertical Diameter", ellipse.VerticalDiameter);
                ellipse.VerticalDiameter = string.IsNullOrEmpty(vDiameter) ? ellipse.VerticalDiameter : Validation.ValidateSizeValue(vDiameter);

                // If all the user input is valid, pass the object on to have a BOM statement constructed
                return BOMBuilder(ellipse);
            }
            // Any problems are caught and an exception is thrown
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Takes a ellipse object and constructs a BOM statement
        /// </summary>
        /// <param name="ellipse">Ellipse object</param>
        /// <returns></returns>
        public string BOMBuilder(Ellipse ellipse)
            => $"Ellipse({ellipse.PositionX},{ellipse.PositionY}) diameterH = {ellipse.HorizontalDiameter} diameterV = {ellipse.VerticalDiameter}";
    }
}
