﻿using System;
using System.Collections.Generic;

namespace BOMApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // List of strings to hold the BOM strings as generated by each processor
                List<string> boms = new List<string>();

                Console.WriteLine("Welcome to the BOM Generator");
                Console.WriteLine("All numeric values should be entered as positive integers greater than 0.");
                Console.WriteLine("If any entries are identified which fail validation, the process will be terminated");
                Console.WriteLine();

                // Generate a Rectangle Widget
                RectangleProcessor rectangleProcessor = new RectangleProcessor();
                boms.Add(rectangleProcessor.Process());

                // Generate a Square Widget
                Console.Clear();
                SquareProcessor squareProcessor = new SquareProcessor();
                boms.Add(squareProcessor.Process());

                // Generate a Ellipse Widget
                Console.Clear();
                EllipseProcessor ellipseProcessor = new EllipseProcessor();
                boms.Add(ellipseProcessor.Process());

                // Generate a Circle Widget
                Console.Clear();
                CircleProcessor circleProcessor = new CircleProcessor();
                boms.Add(circleProcessor.Process());

                // Generate a Textbox Widget
                Console.Clear();
                TextboxProcessor textboxProcessor = new TextboxProcessor();
                boms.Add(textboxProcessor.Process());

                // Construct the Widget Builder input
                Console.Clear();
                Console.WriteLine(OutputBuilder.BuildOutput(boms));
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                // Log any exceptions that are caught
                ErrorLogging.LogError(ex.Message); 

                // Ensures the abort command is actioned if any exceptions are caught
                Console.Clear();
                Console.WriteLine("+++++Abort+++++");
                Console.ReadLine();
            }
        }
    }
}
