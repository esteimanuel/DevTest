using System.Collections.Generic;
using Refactoring.Models;

namespace Refactoring.Services.Commands
{
    public interface ICommandExecutionManager
    {
        CommandExecutionResult Execute(string[] parameters);
        IEnumerable<string> GetTemplates();
    }
}