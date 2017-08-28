namespace Refactoring.UnitTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Helper;
    using Shapes;
    using ConsoleHandler;
    using DTO;
    using System.Collections.Generic;

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
        private const double TrapezoidHeight = 10d;
        private const double TrapezoidBottomBase = 15d;
        private const double TrapezoidTopBase = 8d;
        private const double TrapezoidSurfaceArea = 115d;

        ShapeHelper shapeHandler = new ShapeHelper();
        ComandHandler handler = new ComandHandler(comand);

        private static IComand comand;

        [TestMethod]
        public void TriangleCalculateSurfaceArea()
        {
            // Arrange
            
            IShape triangle = shapeHandler.GetShapeInstance("Triangle");
            triangle.ShapeParamList[0].ParamValue = TriangleHeight;
            triangle.ShapeParamList[1].ParamValue = TriangleWidth;

            // Act
            double surfaceArea = triangle.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(TriangleSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void CircleCalculateSurfaceArea()
        {
            // Arrange
            IShape circle = shapeHandler.GetShapeInstance("Circle");
            circle.ShapeParamList[0].ParamValue = CircleRadius;

            // Act
            double surfaceArea = circle.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(CircleSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void SquareCalculateSurfaceArea()
        {
            // Arrange
            IShape square = shapeHandler.GetShapeInstance("Square");
            square.ShapeParamList[0].ParamValue = SquareSide;

            // Act
            double surfaceArea = square.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(SquareSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void RectangleCalculateSurfaceArea()
        {
            // Arrange
            IShape rectangle = shapeHandler.GetShapeInstance("Rectangle");
            rectangle.ShapeParamList[0].ParamValue = RectangleHeight;
            rectangle.ShapeParamList[1].ParamValue = RectangleWidth;

            // Act
            double surfaceArea = rectangle.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(RectangleSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void CalculateSurfaceAreas()
        {
            // Arrange
            IShape triangle = shapeHandler.GetShapeInstance("Triangle");
            triangle.ShapeParamList[0].ParamValue = TriangleHeight;
            triangle.ShapeParamList[1].ParamValue = TriangleWidth;

            IShape circle = shapeHandler.GetShapeInstance("Circle");
            circle.ShapeParamList[0].ParamValue = CircleRadius;

            IShape square = shapeHandler.GetShapeInstance("Square");
            square.ShapeParamList[0].ParamValue = SquareSide;

            IShape rectangle = shapeHandler.GetShapeInstance("Rectangle");
            rectangle.ShapeParamList[0].ParamValue = RectangleHeight;
            rectangle.ShapeParamList[1].ParamValue = RectangleWidth;

            IShape trapezoid = shapeHandler.GetShapeInstance("Trapezoid");
            trapezoid.ShapeParamList[0].ParamValue = TrapezoidHeight;
            trapezoid.ShapeParamList[1].ParamValue = TrapezoidBottomBase;
            trapezoid.ShapeParamList[2].ParamValue = TrapezoidTopBase;

            double[] expectedSurfaceAreas = new double[] { TriangleSurfaceArea, CircleSurfaceArea, SquareSurfaceArea, RectangleSurfaceArea, TrapezoidSurfaceArea };
            
            // Act
            handler._listOfShapes.Add(triangle);
            handler._listOfShapes.Add(circle);
            handler._listOfShapes.Add(square);
            handler._listOfShapes.Add(rectangle);
            handler._listOfShapes.Add(trapezoid);
            handler._comand = new Comand();
            handler.CalculateSurfaceAreas();
            List<ShapeInfo> surfaceAreas = handler._listOfCalculatedAreas;

            // Assert
            Assert.AreEqual(expectedSurfaceAreas[0], surfaceAreas[0].ShapeAreaSurface);
            Assert.AreEqual(expectedSurfaceAreas[1], surfaceAreas[1].ShapeAreaSurface);
            Assert.AreEqual(expectedSurfaceAreas[2], surfaceAreas[2].ShapeAreaSurface);
            Assert.AreEqual(expectedSurfaceAreas[3], surfaceAreas[3].ShapeAreaSurface);
            Assert.AreEqual(expectedSurfaceAreas[4], surfaceAreas[4].ShapeAreaSurface);
        }
    }
}
