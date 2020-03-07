using System;

namespace BOMApp
{
    public class UserPrompts
    {
        public static string PromptForWidgetValue(string requiredProperty, int defaultValue)
        {
            Console.WriteLine($"Please provide {requiredProperty} as an Integer. Default Value = {defaultValue}:");
            string retVal = Console.ReadLine();

            return retVal;
        }
    }
}
