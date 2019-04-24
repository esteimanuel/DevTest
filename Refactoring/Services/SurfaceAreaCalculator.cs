using System;
using Refactoring.Models;
using Refactoring.Services.Commands;
using Refactoring.Services.Utils;

namespace Refactoring.Services
{
    public class SurfaceAreaCalculator
    {
        private readonly ILogger Logger;
        private readonly ICommandExecutionManager CommandExecutionManager;

        public SurfaceAreaCalculator(ICommandExecutionManager commandExecutionManager, ILogger logger)
        {
            CommandExecutionManager = commandExecutionManager;
            Logger = logger;
        }

        public void Run()
        {
            ShowCommands();

            CommandExecutionResult result;
            do
            {
                var input = Console.ReadLine() ?? "";
                var parameters = input.Split(' ');
                result = CommandExecutionManager.Execute(parameters);

                if (result == CommandExecutionResult.Error)
                {
                    ShowCommands();
                }
            } while (result != CommandExecutionResult.Exit);
        }

        private void ShowCommands()
        {
            Logger.Log("commands:");
            foreach (var commandsTemplate in CommandExecutionManager.GetTemplates())
            {
                Logger.Log($"- {commandsTemplate}");
            }
        }
    }
}