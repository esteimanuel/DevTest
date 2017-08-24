namespace Refactoring.UnitTest
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Refactoring;
    using Moq;

    
    public class TestSurfaceAreaCalculator : SurfaceAreaCalculator
    {

        public bool isInvoked = false;

        public void Test()
        {
            Console.WriteLine("Exit");
            isInvoked = true;
        }
    }


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
        private const double TrapezoidSideA = 12d;
        private const double TrapezoidSideB = 2d;
        private const double TrapezoidHeight = 5d;
        private const double TrapezoidSurfaceArea = 35d;

        [TestMethod]
        public void TriangleCalculateSurfaceArea()
        {
            // Arrange
            Triangle triangle = new Triangle(TriangleHeight, TriangleWidth);


            // Act
            double surfaceArea = triangle.CalculatedSurfaceArea;

            // Assert
            Assert.AreEqual(TriangleSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void CircleCalculateSurfaceArea()
        {
            // Arrange
            Circle circle = new Circle(CircleRadius);


            // Act
            double surfaceArea = circle.CalculatedSurfaceArea;

            // Assert
            Assert.AreEqual(CircleSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void SquareCalculateSurfaceArea()
        {
            // Arrange
            Square square = new Square(SquareSide);


            // Act
            double surfaceArea = square.CalculatedSurfaceArea;

            // Assert
            Assert.AreEqual(SquareSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void RectangleCalculateSurfaceArea()
        {
            // Arrange
            Rectangle rectangle = new Rectangle(RectangleHeight, RectangleWidth);

            // Act
            double surfaceArea = rectangle.CalculatedSurfaceArea;

            // Assert
            Assert.AreEqual(RectangleSurfaceArea, surfaceArea);
        }
        [TestMethod]
        public void TrapezoidCalculateSurfaceArea()
        {
            // Arrange
            Trapezoid trapezoid = new Trapezoid(TrapezoidSideA, TrapezoidSideB, TrapezoidHeight);

            // Act
            double surfaceArea = trapezoid.CalculatedSurfaceArea;

            // Assert
            Assert.AreEqual(TrapezoidSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void CalculateSurfaceAreas()
        {
            // Arrange
            Triangle triangle = new Triangle(TriangleHeight, TriangleWidth);

            Circle circle = new Circle(CircleRadius);

            Square square = new Square(SquareSide);

            Rectangle rectangle = new Rectangle(RectangleHeight, RectangleWidth);

            Trapezoid trapezoid = new Trapezoid(TrapezoidSideA, TrapezoidSideB, TrapezoidHeight);

            double [] expectedSurfaceAreas = new double [] { TriangleSurfaceArea, CircleSurfaceArea, SquareSurfaceArea, RectangleSurfaceArea, TrapezoidSurfaceArea };

            // Act
            SurfaceAreaCalculator surfaceAreaCalculator = new SurfaceAreaCalculator();
            surfaceAreaCalculator.Add(triangle);
            surfaceAreaCalculator.Add(circle);
            surfaceAreaCalculator.Add(square);
            surfaceAreaCalculator.Add(rectangle);
            surfaceAreaCalculator.Add(trapezoid);
            surfaceAreaCalculator.Calculate();
            Dictionary<int, Shape> surfaceAreas = surfaceAreaCalculator.ShapesAreasArr;
            //  double [] surfaceAreas = surfaceAreaCalculator.arrSurfaceAreas;


            // Assert
            Assert.AreEqual(expectedSurfaceAreas [0], surfaceAreas [0].CalculatedSurfaceArea);
            Assert.AreEqual(expectedSurfaceAreas [1], surfaceAreas [1].CalculatedSurfaceArea);
            Assert.AreEqual(expectedSurfaceAreas [2], surfaceAreas [2].CalculatedSurfaceArea);
            Assert.AreEqual(expectedSurfaceAreas [3], surfaceAreas [3].CalculatedSurfaceArea);
        }

        [TestMethod]
        public void Create()
        {
            //Arrange
            SurfaceAreaCalculator surfaceAreaCalculator = new SurfaceAreaCalculator();
            List<string> testParams = new List<string>(new string [] { "circle", "23" });

            //Act
            surfaceAreaCalculator.ParamsList = testParams;
            surfaceAreaCalculator.Create();

            //Assert
            Shape shape = surfaceAreaCalculator.ShapesArr [0];
            Assert.IsInstanceOfType(shape, typeof(Circle));
            Assert.AreEqual(shape.CalculatedSurfaceArea, CircleSurfaceArea);
        }

        //[TestMethod]
        //public void ReadString()
        //{
        //    //Arrange
        //    TestSurfaceAreaCalculator surfaceAreaCalculator = new TestSurfaceAreaCalculator();
        //    List<string> testParams = new List<string>(new string [] { "triangle", "2", "4" });
        //    string input = "test triangle 2 4";
        //    //Act
        //    surfaceAreaCalculator.ReadString(input);
            
        //    //Assert
        //    Assert.AreEqual(surfaceAreaCalculator.ParamsList, testParams);
        //    Assert.AreEqual(surfaceAreaCalculator.isInvoked, true);
        //}
    }
}
