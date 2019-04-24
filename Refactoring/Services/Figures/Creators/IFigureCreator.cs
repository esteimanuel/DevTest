using Refactoring.Models;
using Refactoring.Models.Figures;

namespace Refactoring.Services.Figures.Creators
{
    public interface IFigureCreator
    {
        string Name { get; }
        string[] RequiredParameters { get; }
        OperationResult<Figure> Create(string[] parameters);
    }
}
