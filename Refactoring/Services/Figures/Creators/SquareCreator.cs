using Refactoring.Models;
using Refactoring.Models.Figures;

namespace Refactoring.Services.Figures.Creators
{
    public class SquareCreator : BaseFigureCreator
    {
        public override string Name => "square";
        public override string[] RequiredParameters => new[] { "side" };

        protected override OperationResult<Figure> CreateFigure(string[] parameters)
        {
            if (double.TryParse(parameters[0], out var side))
            {
                return OperationResult<Figure>.Success(new Square(side));
            }

            return OperationResult<Figure>.Failure("Incorrect format of parameter 'side'.");
        }
    }
}