using Refactoring.Application.Interfaces.Commands.AreaCalculator;
using Refactoring.Application.Exceptions;
using Refactoring.Application.Interfaces.Services;
using Refactoring.Helpers;
using System;
using Unity;

namespace Refactoring
{
    internal class Program
    {
        public static ILogger Logger { get; set; }
        public static IAreaCalculatorCommandInterpreter AreaCalculatorCommandInterpreter { get; set; }

        public const string ExitKeyword = "exit";

        private static void Main(string[] args)
        {
            using (var container = Bootstrapper.Container)
            {
                Init(container); 

                do
                {
                    var userInput = Console.ReadLine();
                    if (userInput.Equals(ExitKeyword, StringComparison.InvariantCultureIgnoreCase))
                        break;

                    ProcessUserInput(userInput);
                } while (true);
            }
                
        }

        private static void Init(IUnityContainer container)
        {
            Logger = container.Resolve<ILogger>();
            AreaCalculatorCommandInterpreter = container.Resolve<IAreaCalculatorCommandInterpreter>();

            MessageHelper.ShowWelcomeMessage();
            MessageHelper.ShowCommands();
        }

        private static void ProcessUserInput(string userInput)
        {
            try
            {
                AreaCalculatorCommandInterpreter.InterpretAreaCalculatorCommand(userInput).Execute();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                if (ex is UnknownCommandException)
                    MessageHelper.ShowCommands();
            }
        }
    }
}