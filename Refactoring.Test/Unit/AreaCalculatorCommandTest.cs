using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.Application.Commands.AreaCalculator;
using Refactoring.Application.Enums;
using Refactoring.Application.Interfaces.Repository;
using Refactoring.Application.Interfaces.Services;
using Refactoring.Application.Models.Shapes;
using Unity;

namespace Refactoring.Test.Unit
{
    [TestClass]
    public class AreaCalculatorCommandTest : UnitTestBase
    {
        [TestMethod, TestCategory("Unit")]
        public void Execute_Calculate()
        {
            // Arrange
            var mockedLogger = MockContainer.Resolve<ILogger>();
            var mockedShapeRepository = MockContainer.Resolve<IShapeRepository>();

            Triangle triangle = new Triangle(TriangleHeight, TriangleWidth);
            Circle circle = new Circle(CircleRadius);
            Square square = new Square(SquareSide);
            Rectangle rectangle = new Rectangle(RectangleHeight, RectangleWidth);
            Trapezoid trapezoid = new Trapezoid(TrapezoidSideA, TrapezoidSideB, TrapezoidHeight);

            double[] expectedSurfaceAreas = new double[] { TriangleSurfaceArea, CircleSurfaceArea, SquareSurfaceArea, RectangleSurfaceArea, TrapezoidSurfaceArea };
         
            mockedShapeRepository.Add(triangle);
            mockedShapeRepository.Add(circle);
            mockedShapeRepository.Add(square);
            mockedShapeRepository.Add(rectangle);
            mockedShapeRepository.Add(trapezoid);

            var areaCalculatorCommand = new AreaCalculatorCommand(mockedShapeRepository, mockedLogger, AreaCalculatorOperations.Calculate);

            // Act
            areaCalculatorCommand.Execute();

            // Assert
            int i = 0;
            foreach (var shape in mockedShapeRepository.GetAll())
            {
                Assert.AreEqual(expectedSurfaceAreas[i], shape.Area);
                i++;
            }
        }

        // TODO: Test other operation executions
    }
}