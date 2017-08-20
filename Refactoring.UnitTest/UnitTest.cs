﻿// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// UnitTest.cs 
// 20 / 08 / 2017

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Refactoring.DataModels.Input;
using Refactoring.DataModels.Logging;
using Refactoring.DataModels.Shapes;

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
        private const double TrapezoidTopBase = 25.5d;
        private const double TrapezoidBottomBase = 35.5d;
        private const double TrapezoidHeight = 15d;
        private const double TrapezoidSurfaceArea = 457.5d;


        [TestMethod]
        public void TriangleCalculateSurfaceArea()
        {
            // Arrange
            Triangle triangle = new Triangle
            {
                Height = TriangleHeight,
                Width = TriangleWidth
            };

            // Act
            triangle.CalculateSurfaceArea();
            double surfaceArea = triangle.SurfaceArea;

            // Assert
            Assert.AreEqual(TriangleSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void CircleCalculateSurfaceArea()
        {
            // Arrange
            Circle circle = new Circle {Radius = CircleRadius};

            // Act
            circle.CalculateSurfaceArea();
            double surfaceArea = circle.SurfaceArea;

            // Assert
            Assert.AreEqual(CircleSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void SquareCalculateSurfaceArea()
        {
            // Arrange
            Square square = new Square {Side = SquareSide};

            // Act
            square.CalculateSurfaceArea();
            double surfaceArea = square.SurfaceArea;

            // Assert
            Assert.AreEqual(SquareSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void RectangleCalculateSurfaceArea()
        {
            // Arrange
            Rectangle rectangle = new Rectangle
            {
                Height = RectangleHeight,
                Width = RectangleWidth
            };

            // Act
            rectangle.CalculateSurfaceArea();
            double surfaceArea = rectangle.SurfaceArea;

            // Assert
            Assert.AreEqual(RectangleSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void TrapezoidCalculateSurfaceArea()
        {
            //Arrange
            Trapezoid trapezoid = new Trapezoid
            {
                BaseTop = TrapezoidTopBase,
                BaseBottom = TrapezoidBottomBase,
                Height = TrapezoidHeight
            };

            //Act
            trapezoid.CalculateSurfaceArea();
            double surfaceArea = trapezoid.SurfaceArea;


            //Assert
            Assert.AreEqual(TrapezoidSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void CalculateSurfaceAreas()
        {
            // Arrange
            ILogger logMock = Mock.Of<ILogger>();
            Triangle triangle = new Triangle();
            triangle.Height = TriangleHeight;
            triangle.Width = TriangleWidth;

            Circle circle = new Circle();
            circle.Radius = CircleRadius;

            Square square = new Square();
            square.Side = SquareSide;

            Rectangle rectangle = new Rectangle();
            rectangle.Height = RectangleHeight;
            rectangle.Width = RectangleWidth;

            // TODO: Implement a new Trapezoid shape

            double[] expectedSurfaceAreas =
                {TriangleSurfaceArea, CircleSurfaceArea, SquareSurfaceArea, RectangleSurfaceArea};

            // Act
            SurfaceAreaCalculator surfaceAreaCalculator = new SurfaceAreaCalculator(logMock);
            surfaceAreaCalculator.Add(triangle);
            surfaceAreaCalculator.Add(circle);
            surfaceAreaCalculator.Add(square);
            surfaceAreaCalculator.Add(rectangle);
            // TODO: surfaceAreaCalculator.Add(trapezoid);
            surfaceAreaCalculator.CalculateSurfaceAreas();
            double[] surfaceAreas = surfaceAreaCalculator.ArrSurfaceAreas;

            // Assert
            Assert.AreEqual(expectedSurfaceAreas[0], surfaceAreas[0]);
            Assert.AreEqual(expectedSurfaceAreas[1], surfaceAreas[1]);
            Assert.AreEqual(expectedSurfaceAreas[2], surfaceAreas[2]);
            Assert.AreEqual(expectedSurfaceAreas[3], surfaceAreas[3]);
        }

    }
}