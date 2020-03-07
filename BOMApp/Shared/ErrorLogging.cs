using System;
using System.IO;

namespace BOMApp
{
    public class ErrorLogging
    {
        private static string ErrorLogLocation = @"c:\temp\";
        private static readonly string ErrorLogFileName = @"BOMErrorLog.txt";

        public static void LogError(string error)
        {
            try
            {
                if (!Directory.Exists(ErrorLogLocation))
                    Directory.CreateDirectory(ErrorLogLocation);
            }
            catch
            {
                ErrorLogLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }

            string logEntry = GenerateLogEntry(error);

            File.AppendAllText(Path.Combine(ErrorLogLocation, ErrorLogFileName), logEntry);
        }

        public static string GenerateLogEntry(string error)
            => $"{DateTime.Now}, {Environment.UserName}, {error}\r\n";

    }
}
