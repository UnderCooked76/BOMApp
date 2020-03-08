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
            Textbox textbox = new Textbox();

            Console.WriteLine("Please enter the values for your Textbox Widget");
            try
            {
                // Prompt to user for X Postion
                string posX = UserPrompts.PromptForWidgetValue("Position X", textbox.PositionX);

                // Validate the user input. If valid, stores the value in the object
                textbox.PositionX = string.IsNullOrEmpty(posX) ? textbox.PositionX : Validation.ValidatePositionValue(posX);

                string posY = UserPrompts.PromptForWidgetValue("Position Y", textbox.PositionY);
                textbox.PositionY = string.IsNullOrEmpty(posY) ? textbox.PositionY : Validation.ValidatePositionValue(posY);

                string width = UserPrompts.PromptForWidgetValue("Width", textbox.Width);
                textbox.Width = string.IsNullOrEmpty(width) ? textbox.Width : Validation.ValidateSizeValue(width);

                string height = UserPrompts.PromptForWidgetValue("Height", textbox.Height);
                textbox.Height = string.IsNullOrEmpty(height) ? textbox.Height : Validation.ValidateSizeValue(height);

                Console.WriteLine($"Please provide the Text you require. Default Text = {textbox.Text}");
                string text = Console.ReadLine();
                textbox.Text = string.IsNullOrEmpty(text) ? textbox.Text : text;

                // If all the user input is valid, pass the object on to have a BOM statement constructed
                return BOMBuilder(textbox);
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
        /// <param name="textbox">Textbox object</param>
        /// <returns></returns>
        public string BOMBuilder(Textbox textbox)
            => $"Textbox({textbox.PositionX},{textbox.PositionY}) width={textbox.Width} height={textbox.Height} text=\"{textbox.Text}\"";
    }
}
