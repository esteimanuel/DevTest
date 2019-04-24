using System.Collections.Generic;
using Refactoring.Models;

namespace Refactoring.Services.Commands.Executors
{
    public class ExitCommandExecutor : ICommandExecutor
    {
        public string Name => "exit";

        public CommandExecutionResult Execute(string[] parameters)
        {
            return CommandExecutionResult.Exit;
        }

        public IEnumerable<string> GetTemplates()
        {
            return new[] { "(exit the loop)" };
        }
    }
}