using System.Collections.Generic;
using System.Linq;
using System.Text;
using Refactoring.Models;
using Refactoring.Services.Figures;
using Refactoring.Services.Utils;

namespace Refactoring.Services.Commands.Executors
{
    public class PrintCommandExecutor : ICommandExecutor
    {
        private readonly IFiguresStorage FiguresStorage;
        private readonly ILogger Logger;

        public PrintCommandExecutor(IFiguresStorage figuresStorage, ILogger logger)
        {
            FiguresStorage = figuresStorage;
            Logger = logger;
        }

        public string Name => "print";

        public CommandExecutionResult Execute(string[] parameters)
        {
            var figures = FiguresStorage.GetAll().ToList();

            if (figures.Count > 0)
            {
                var sb = new StringBuilder();
                var i = 0;
                foreach (var figure in figures)
                {
                    sb.AppendLine($"[{i++}] {figure.GetType().Name} surface area is {figure.CalculateSurfaceArea()}");
                }

                Logger.Log(sb.ToString());
                return CommandExecutionResult.Success;
            }

            Logger.Log("There are no surface areas to print");
            return CommandExecutionResult.Success;
        }

        public IEnumerable<string> GetTemplates()
        {
            return new[] { "(print the calculated surface areas)" };
        }
    }
}