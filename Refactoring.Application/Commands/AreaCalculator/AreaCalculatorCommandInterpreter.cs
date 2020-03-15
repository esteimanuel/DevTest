using Refactoring.Application.Interfaces.Commands.AreaCalculator;
using Refactoring.Application.Enums;
using Refactoring.Application.Exceptions;
using Refactoring.Application.Models;
using Refactoring.Application.Models.Shapes;
using Refactoring.Application.Interfaces.Repository;
using Refactoring.Application.Interfaces.Services;
using System;
using System.Text.RegularExpressions;
using Unity;
using Refactoring.Application.Extensions;

using Rgx = Refactoring.Application.Helpers.AreaCalculatorCommandRegexHelper;

namespace Refactoring.Application.Commands.AreaCalculator
{
    public class AreaCalculatorCommandInterpreter : IAreaCalculatorCommandInterpreter
    {
        [Dependency]
        public Lazy<IShapeRepository> ShapeRepositoryLazy { get; set; }
        public IShapeRepository ShapeRepository => ShapeRepositoryLazy.Value;

        [Dependency]
        public ILogger Logger { get; set; }

        public IAreaCalculatorCommand InterpretAreaCalculatorCommand(string userInput)
        {
            if (userInput.StartsWith(nameof(AreaCalculatorOperations.Create), StringComparison.InvariantCultureIgnoreCase))
                return InterpretCreateShapeCommand(userInput);
            else if (userInput.Equals(nameof(AreaCalculatorOperations.Calculate), StringComparison.InvariantCultureIgnoreCase))
                return new AreaCalculatorCommand(ShapeRepository, Logger, AreaCalculatorOperations.Calculate);
            else if (userInput.Equals(nameof(AreaCalculatorOperations.Print), StringComparison.InvariantCultureIgnoreCase))
                return new AreaCalculatorCommand(ShapeRepository, Logger, AreaCalculatorOperations.Print);
            else if (userInput.Equals(nameof(AreaCalculatorOperations.Reset), StringComparison.InvariantCultureIgnoreCase))
                return new AreaCalculatorCommand(ShapeRepository, Logger, AreaCalculatorOperations.Reset);

            throw new UnknownCommandException();
        }

        private IAreaCalculatorCommand InterpretCreateShapeCommand(string userInput)
        {
            var shape = GetShapeFromInput(userInput);

            if (!(shape is null))
                return new AreaCalculatorCommand(ShapeRepository, Logger, AreaCalculatorOperations.Create, shape);

            throw new UnknownCommandException();
        }

        private Shape GetShapeFromInput(string userInput)
        {
            Shape shape = null;

            var userInputParts = userInput.Split(' ');

            var firstDim = userInputParts.ParsePossibleDouble(2);
            var secondDim = userInputParts.ParsePossibleDouble(3);
            var thirdDim = userInputParts.ParsePossibleDouble(4);

            try
            {
                if (Regex.IsMatch(userInput, Rgx.CreateSquarePattern, RegexOptions.IgnoreCase))
                    shape = new Square(firstDim.Value);
                else if (Regex.IsMatch(userInput, Rgx.CreateCirclePattern, RegexOptions.IgnoreCase))
                    shape = new Circle(firstDim.Value);
                else if (Regex.IsMatch(userInput, Rgx.CreateRectanglePattern, RegexOptions.IgnoreCase))
                    shape = new Rectangle(firstDim.Value, secondDim.Value);
                else if (Regex.IsMatch(userInput, Rgx.CreateTrianglePattern, RegexOptions.IgnoreCase))
                    shape = new Triangle(firstDim.Value, secondDim.Value);
                else if (Regex.IsMatch(userInput, Rgx.CreateTrapezoidPattern, RegexOptions.IgnoreCase))
                    shape = new Trapezoid(firstDim.Value, secondDim.Value, thirdDim.Value);
            }
            catch
            {
                throw new UnknownCommandException();
            }

            return shape;
        }
    }
}