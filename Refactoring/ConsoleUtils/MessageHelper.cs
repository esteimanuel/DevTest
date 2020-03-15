using System;
using Refactoring.Properties;

namespace Refactoring.Helpers
{
    public static class MessageHelper
    {
        public static void ShowWelcomeMessage()
        {
            ShowMessage(Resources.WelcomeMessage);
        }

        public static void ShowCommands()
        {
            ShowMessage(Resources.Commands);
        }

        private static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}