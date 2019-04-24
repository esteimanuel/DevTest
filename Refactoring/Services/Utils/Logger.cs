using System;

namespace Refactoring.Services.Utils
{
    public class Logger : ILogger
    {
        public void Log(string text)
        {
            Console.WriteLine(text);
        }
    }
}