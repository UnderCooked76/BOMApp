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
            Ellipse ellipses = new Ellipse();

            try
            {
                // Prompt to user for X Postion
                string posX = UserPrompts.PromptForWidgetValue("Position X", ellipses.PositionX);

                // Validate the user input. If valid, stores the value in the object
                ellipses.PositionX = string.IsNullOrEmpty(posX) ? ellipses.PositionX : Validation.ValidatePositionValue(posX);

                string posY = UserPrompts.PromptForWidgetValue("Position Y", ellipses.PositionY);
                ellipses.PositionY = string.IsNullOrEmpty(posY) ? ellipses.PositionY : Validation.ValidatePositionValue(posY);

                string hDiameter = UserPrompts.PromptForWidgetValue("Horizontal Diameter", ellipses.HorizontalDiameter);
                ellipses.HorizontalDiameter = string.IsNullOrEmpty(hDiameter) ? ellipses.HorizontalDiameter : Validation.ValidateSizeValue(hDiameter);

                string vDiameter = UserPrompts.PromptForWidgetValue("Vertical Diameter", ellipses.VerticalDiameter);
                ellipses.VerticalDiameter = string.IsNullOrEmpty(vDiameter) ? ellipses.VerticalDiameter : Validation.ValidateSizeValue(vDiameter);

                // If all the user input is valid, pass the object on to have a BOM statement constructed
                return BOMBuilder(ellipses);
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
        /// <param name="ellipses">Ellipse object</param>
        /// <returns></returns>
        public string BOMBuilder(Ellipse ellipses)
            => $"Ellipse({ellipses.PositionX},{ellipses.PositionY}) diameterH = {ellipses.HorizontalDiameter} diameterV = {ellipses.VerticalDiameter}";
    }
}
