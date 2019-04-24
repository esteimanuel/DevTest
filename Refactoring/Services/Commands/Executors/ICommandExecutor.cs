using System.Collections.Generic;
using Refactoring.Models;

namespace Refactoring.Services.Commands.Executors
{
    public interface ICommandExecutor
    {
        string Name { get; }
        CommandExecutionResult Execute(string[] parameters);
        IEnumerable<string> GetTemplates();
    }
}