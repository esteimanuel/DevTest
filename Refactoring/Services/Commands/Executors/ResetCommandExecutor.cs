using System.Collections.Generic;
using Refactoring.Models;
using Refactoring.Services.Figures;
using Refactoring.Services.Utils;

namespace Refactoring.Services.Commands.Executors
{
    public class ResetCommandExecutor : ICommandExecutor
    {
        private readonly IFiguresStorage FiguresStorage;
        private readonly ILogger Logger;

        public ResetCommandExecutor(IFiguresStorage figuresStorage, ILogger logger)
        {
            FiguresStorage = figuresStorage;
            Logger = logger;
        }

        public string Name => "reset";

        public CommandExecutionResult Execute(string[] parameters)
        {
            FiguresStorage.Reset();
            Logger.Log("Reset state!!");
            return CommandExecutionResult.Success;
        }

        public IEnumerable<string> GetTemplates()
        {
            return new[] { "(reset)" };
        }
    }
}