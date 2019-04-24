using Refactoring.Models;
using Refactoring.Models.Figures;

namespace Refactoring.Services.Figures.Creators
{
    public class TriangleCreator : BaseFigureCreator
    {
        public override string Name => "triangle";
        public override string[] RequiredParameters => new[] { "height", "width" };

        protected override OperationResult<Figure> CreateFigure(string[] parameters)
        {
            if (double.TryParse(parameters[0], out var height) && double.TryParse(parameters[1], out var width))
            {
                return OperationResult<Figure>.Success(new Triangle(height, width));
            }

            return OperationResult<Figure>.Failure("Incorrect format of parameter 'height' or 'width'.");
        }
    }
}