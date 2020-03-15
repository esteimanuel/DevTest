using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.Application.Models.Shapes;
using System;

namespace Refactoring.Test.Unit
{
    [TestClass]
    public class ShapeTest : TestBase
    {
        [TestMethod, TestCategory("Unit")]
        public void Triangle_CalculateSurfaceArea()
        {
            // Arrange
            var triangle = new Triangle(TriangleHeight, TriangleWidth);

            // Act
            triangle.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(TriangleSurfaceArea, triangle.Area);
        }

        [TestMethod, TestCategory("Unit")]
        public void Circle_CalculateSurfaceArea()
        {
            // Arrange
            var circle = new Circle(CircleRadius);

            // Act
            circle.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(CircleSurfaceArea, circle.Area);
        }

        [TestMethod, TestCategory("Unit")]
        public void Square_CalculateSurfaceArea()
        {
            // Arrange
            var square = new Square(SquareSide);

            // Act
            square.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(SquareSurfaceArea, square.Area);
        }

        [TestMethod, TestCategory("Unit")]
        public void Rectangle_CalculateSurfaceArea()
        {
            // Arrange
            var rectangle = new Rectangle(RectangleHeight, RectangleWidth);

            // Act
            rectangle.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(RectangleSurfaceArea, rectangle.Area);
        }

        [TestMethod, TestCategory("Unit")]
        public void Trapezoid_CalculateSurfaceArea()
        {
            // Arrange
            var trapezoid = new Trapezoid(TrapezoidSideA, TrapezoidSideB, TrapezoidHeight);

            // Act
            trapezoid.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(TrapezoidSurfaceArea, trapezoid.Area);
        }

        [TestMethod, TestCategory("Unit")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Rectangle_Construct_InvalidHeight_ShouldThrowArgumentOutOfRangeException()
        {
            // Act
            new Rectangle(-1, RectangleWidth);
        }

        [TestMethod, TestCategory("Unit")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Rectangle_Construct_InvalidWidth_ShouldThrowArgumentOutOfRangeException()
        {
            // Act
            new Rectangle(RectangleHeight, 0);
        }

        // TODO: Repeat above constructor validation tests for every shape
    }
}