using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.Application.Interfaces.Commands.AreaCalculator;
using Refactoring.Application.Interfaces.Repository;
using Refactoring.Application.Models.Shapes;
using System.Collections.Generic;
using System.Linq;
using Unity;

namespace Refactoring.Test.Real
{
    [TestClass]
    public class AreaCalculatorTest : RealTestBase
    {
        [TestMethod, TestCategory("Real")]
        public void CreateThreeShapes_ThenCalculate_ThenResetState()
        {
            // Arrange
            const string inputCreateSquare = "create square 4";
            const string inputCreateTrapezoid = "create trapezoid 2 3 4";
            const string inputCreateTriangle = "create triangle 4 3";
            const string inputCalculate = "calculate";
            const string inputReset = "reset";

            var inputPipeline = new List<string> { inputCreateSquare, inputCreateTrapezoid, inputCreateTriangle, inputCalculate };

            var areaCalculatorCommandInterpreter = RealContainer.Resolve<IAreaCalculatorCommandInterpreter>();
            var shapeRepository = RealContainer.Resolve<IShapeRepository>();

            // Act
            inputPipeline.ForEach(input => areaCalculatorCommandInterpreter.InterpretAreaCalculatorCommand(input).Execute());

            // Assert
            var shapes = shapeRepository.GetAll().ToList();
            var square = shapes.SingleOrDefault(shape => shape is Square);
            var trapezoid = shapes.SingleOrDefault(shape => shape is Trapezoid);
            var triangle = shapes.SingleOrDefault(shape => shape is Triangle);

            Assert.AreEqual(3, shapes.Count());
            Assert.IsNotNull(square);
            Assert.IsNotNull(trapezoid);
            Assert.IsNotNull(triangle);
            Assert.AreEqual(16, square.Area);
            Assert.AreEqual(10, trapezoid.Area);
            Assert.AreEqual(6, triangle.Area);

            // Act
            areaCalculatorCommandInterpreter.InterpretAreaCalculatorCommand(inputReset).Execute();

            // Assert
            shapes = shapeRepository.GetAll().ToList();
            Assert.AreEqual(0, shapes.Count());
        }
    }
}