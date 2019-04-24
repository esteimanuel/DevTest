using Refactoring.Models;
using Refactoring.Models.Figures;

namespace Refactoring.Services.Figures.Creators
{
    public class TrapezoidCreator : BaseFigureCreator
    {
        public override string Name => "trapezoid";
        public override string[] RequiredParameters => new[] { "side1", "side2", "height" };

        protected override OperationResult<Figure> CreateFigure(string[] parameters)
        {
            if (double.TryParse(parameters[0], out var side1) &&
                double.TryParse(parameters[1], out var side2) &&
                double.TryParse(parameters[2], out var height))
            {
                return OperationResult<Figure>.Success(new Trapezoid(side1, side2, height));
            }

            return OperationResult<Figure>.Failure("Incorrect format of parameter 'side1' or 'side2' or 'height'.");
        }
    }
}