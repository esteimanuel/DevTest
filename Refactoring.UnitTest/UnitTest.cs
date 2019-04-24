using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.Models;
using Refactoring.Models.Figures;
using Refactoring.Services;

namespace Refactoring.UnitTest
{
    [TestClass]
    public class UnitTest
    {
        private const double TriangleHeight = 13d;
        private const double TriangleWidth = 34d;
        private const double TriangleSurfaceArea = 221d;
        private const double CircleRadius = 23d;
        private const double CircleSurfaceArea = 1661.9d;
        private const double SquareSide = 17d;
        private const double SquareSurfaceArea = 289d;
        private const double RectangleHeight = 23d;
        private const double RectangleWidth = 67d;
        private const double RectangleSurfaceArea = 1541d;
        private const double TrapezoidSide1 = 64d;
        private const double TrapezoidSide2 = 87d;
        private const double TrapezoidHeight = 28d;
        private const double TrapezoidSurfaceArea = 2114d;

        [TestMethod]
        public void TriangleCalculateSurfaceArea()
        {
            // Arrange
            Triangle triangle = new Triangle(TriangleHeight, TriangleWidth);

            // Act
            double surfaceArea = triangle.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(TriangleSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void CircleCalculateSurfaceArea()
        {
            // Arrange
            Circle circle = new Circle(CircleRadius);

            // Act
            double surfaceArea = circle.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(CircleSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void SquareCalculateSurfaceArea()
        {
            // Arrange
            Square square = new Square(SquareSide);

            // Act
            double surfaceArea = square.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(SquareSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void RectangleCalculateSurfaceArea()
        {
            // Arrange
            Rectangle rectangle = new Rectangle(RectangleHeight, RectangleWidth);

            // Act
            double surfaceArea = rectangle.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(RectangleSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void TrapezoidCalculateSurfaceArea()
        {
            // Arrange
            Trapezoid trapezoid = new Trapezoid(TrapezoidSide1, TrapezoidSide2, TrapezoidHeight);

            // Act
            double surfaceArea = trapezoid.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(TrapezoidSurfaceArea, surfaceArea);
        }
    }
}
