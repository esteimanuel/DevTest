using System.Collections.Generic;
using System.Linq;
using Refactoring.Models;
using Refactoring.Models.Figures;
using Refactoring.Services.Figures.Creators;

namespace Refactoring.Services.Figures
{
    public class FigureCreationManager : IFigureCreationManager
    {
        private readonly IList<IFigureCreator> Creators;

        public FigureCreationManager(IList<IFigureCreator> creators)
        {
            Creators = creators;
        }

        public OperationResult<Figure> Create(string figureType, string[] parameters)
        {
            var creator = Creators.SingleOrDefault(c => c.Name.Equals(figureType));

            if (creator == null)
            {
                return OperationResult<Figure>.Failure($"Unknown figure type [{figureType}]");
            }

            return creator.Create(parameters);
        }

        public IEnumerable<string> GetTemplates()
        {
            return Creators.Select(c => GetFigureTemplate(c.Name, c.RequiredParameters));
        }

        private string GetFigureTemplate(string figureName, string[] requiredParameters)
        {
            var result = $"{figureName}";

            foreach (var requiredParameter in requiredParameters)
            {
                result += $" {{{requiredParameter}}}";
            }

            result += $" (create a new {figureName})";

            return result;
        }
    }
}