using System.Collections.Generic;
using Refactoring.Models;
using Refactoring.Models.Figures;

namespace Refactoring.Services.Figures
{
    public interface IFigureCreationManager
    {
        OperationResult<Figure> Create(string figureType, string[] parameters);
        IEnumerable<string> GetTemplates();
    }
}