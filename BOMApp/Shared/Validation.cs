using System;

namespace BOMApp
{
    public class Validation
    {
        /// <summary>
        /// Confirms that the provided value is an integer, greater than 0
        /// </summary>
        /// <param name="input">string to be validated</param>
        /// <returns>converted integer</returns>
        public static int ValidateSizeValue(string input)
        {
            if (Int32.TryParse(input, out int count))
            {
                if (count > 0)
                    return count;
                else
                    // New exception with a specific message that will be logged
                    throw new Exception($"Input value '{input}' was not greater than 0");
            }
            else
            {
                // New exception with a specific message that will be logged
                throw new Exception($"Unable to transform input value '{input}' to a numeric value");
            }
        }


        /// <summary>
        /// Confirms that the provided value is an integer and is not a negative number
        /// </summary>
        /// <param name="input">string to be validated</param>
        /// <returns>converted integer</returns>
        public static int ValidatePositionValue(string input)
        {
            if (Int32.TryParse(input, out int count))
            {
                if (count >= 0)
                    return count;
                else
                    // New exception with a specific message that will be logged
                    throw new Exception($"Input value {input} was a negative value");
            }
            else
            {
                // New exception with a specific message that will be logged
                throw new Exception($"Unable to transform input value '{input}' to a number");
            }
        }
    }
}
