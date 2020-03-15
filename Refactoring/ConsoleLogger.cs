using System;
using Refactoring.Application.Interfaces.Services;

namespace Refactoring
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string text)
        {
            Console.WriteLine(text);
        }

        public void LogError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void LogError(Exception ex)
        {
            LogError(ex.Message);
        }
    }
}