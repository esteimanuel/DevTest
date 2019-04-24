using System.Collections.Generic;
using System.Linq;
using Refactoring.Models;
using Refactoring.Services.Commands.Executors;
using Refactoring.Services.Utils;

namespace Refactoring.Services.Commands
{
    public class CommandExecutionManager : ICommandExecutionManager
    {
        private readonly IList<ICommandExecutor> CommandExecutors;
        private readonly ILogger Logger;

        public CommandExecutionManager(IList<ICommandExecutor> commandExecutors, ILogger logger)
        {
            CommandExecutors = commandExecutors;
            Logger = logger;
        }

        public CommandExecutionResult Execute(string[] parameters)
        {
            var commandExecutor =
                CommandExecutors.SingleOrDefault(e => parameters.Length > 0 && e.Name.Equals(parameters[0]));

            if (commandExecutor != null)
            {
                return commandExecutor.Execute(parameters.Skip(1).ToArray());
            }

            Logger.Log("Unknown command!!!");
            return CommandExecutionResult.Error;
        }

        public IEnumerable<string> GetTemplates()
        {
            return CommandExecutors.SelectMany(x =>
            {
                var commandTemplates = x.GetTemplates().ToArray();

                return commandTemplates.Any() ? commandTemplates.Select(d => $"{x.Name} {d}") : new[] { x.Name };
            });
        }
    }
}