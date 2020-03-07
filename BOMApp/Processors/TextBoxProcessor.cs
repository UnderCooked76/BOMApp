using System;

namespace BOMApp
{
    public class TextboxProcessor : IProcessor<Textbox>
    {
        /// <summary>
        /// Process for generating a Textbox Widget Order
        /// </summary>
        /// <returns>string for a Textbox Widget</returns>
        public string Process()
        {
            Textbox textboxes = new Textbox();

            try
            {
                // Prompt to user for X Postion
                string posX = UserPrompts.PromptForWidgetValue("Position X", textboxes.PositionX);

                // Validate the user input. If valid, stores the value in the object
                textboxes.PositionX = string.IsNullOrEmpty(posX) ? textboxes.PositionX : Validation.ValidatePositionValue(posX);

                string posY = UserPrompts.PromptForWidgetValue("Position Y", textboxes.PositionY);
                textboxes.PositionY = string.IsNullOrEmpty(posY) ? textboxes.PositionY : Validation.ValidatePositionValue(posY);

                string width = UserPrompts.PromptForWidgetValue("Width", textboxes.Width);
                textboxes.Width = string.IsNullOrEmpty(width) ? textboxes.Width : Validation.ValidateSizeValue(width);

                string height = UserPrompts.PromptForWidgetValue("Height", textboxes.Height);
                textboxes.Height = string.IsNullOrEmpty(height) ? textboxes.Height : Validation.ValidateSizeValue(height);

                Console.WriteLine($"Please provide the Text you require. Default Text = {textboxes.Text}");
                string text = Console.ReadLine();
                textboxes.Text = string.IsNullOrEmpty(text) ? textboxes.Text : text;

                // If all the user input is valid, pass the object on to have a BOM statement constructed
                return BOMBuilder(textboxes);
            }
            // Any problems are caught and an exception is thrown
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Takes a textbox object and constructs a BOM statement
        /// </summary>
        /// <param name="textboxes">Textbox object</param>
        /// <returns></returns>
        public string BOMBuilder(Textbox textboxes)
            => $"Textbox({textboxes.PositionX},{textboxes.PositionY}) width={textboxes.Width} height={textboxes.Height} text=\"{textboxes.Text}\"";
    }
}
