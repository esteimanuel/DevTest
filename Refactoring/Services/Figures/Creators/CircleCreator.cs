using Refactoring.Models;
using Refactoring.Models.Figures;

namespace Refactoring.Services.Figures.Creators
{
    public class CircleCreator : BaseFigureCreator
    {
        public override string Name => "circle";
        public override string[] RequiredParameters => new[] { "radius" };

        protected override OperationResult<Figure> CreateFigure(string[] parameters)
        {
            if (double.TryParse(parameters[0], out var radius))
            {
                return OperationResult<Figure>.Success(new Circle(radius));
            }

            return OperationResult<Figure>.Failure("Incorrect format of parameter 'radius'.");
        }
    }
}