using System.Collections.Generic;
using System.Linq;
using Refactoring.Models;
using Refactoring.Services.Figures;
using Refactoring.Services.Utils;

namespace Refactoring.Services.Commands.Executors
{
    public class CreateCommandExecutor : ICommandExecutor
    {
        private readonly IFiguresStorage FiguresStorage;
        private readonly ILogger Logger;
        private readonly IFigureCreationManager FiguresCreationManager;

        public CreateCommandExecutor(IFiguresStorage figuresStorage, IFigureCreationManager figuresCreationManager,
            ILogger logger)
        {
            FiguresStorage = figuresStorage;
            FiguresCreationManager = figuresCreationManager;
            Logger = logger;
        }

        public string Name => "create";

        public CommandExecutionResult Execute(string[] parameters)
        {
            if (parameters.Length < 1)
            {
                Logger.Log("Figure type is missing.");
                return CommandExecutionResult.Error;
            }

            var figureCreation = FiguresCreationManager.Create(parameters[0], parameters.Skip(1).ToArray());

            if (!figureCreation.Succeeded)
            {
                Logger.Log(figureCreation.ErrorMessage);
                return CommandExecutionResult.Error;
            }

            FiguresStorage.Add(figureCreation.Value);

            Logger.Log($"{figureCreation.Value.GetType().Name} created!");
            return CommandExecutionResult.Success;
        }

        public IEnumerable<string> GetTemplates()
        {
            return FiguresCreationManager.GetTemplates();
        }
    }
}