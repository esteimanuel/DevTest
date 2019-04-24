using Refactoring.Models;
using Refactoring.Models.Figures;

namespace Refactoring.Services.Figures.Creators
{
    public abstract class BaseFigureCreator : IFigureCreator
    {
        public abstract string Name { get; }
        public abstract string[] RequiredParameters { get; }
        public OperationResult<Figure> Create(string[] parameters)
        {
            if (parameters.Length != RequiredParameters.Length)
            {
                return OperationResult<Figure>.Failure("Invalid number of parameters.");
            }

            return CreateFigure(parameters);
        }

        protected abstract OperationResult<Figure> CreateFigure(string[] parameters);
    }
}