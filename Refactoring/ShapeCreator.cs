// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// ShapeCreator.cs 
// 20 / 08 / 2017

using System.Linq;
using Refactoring.DataModels.Input;
using Refactoring.DataModels.Logging;
using Refactoring.DataModels.Shapes;
using Refactoring.Enums;

namespace Refactoring
{
    public class ShapeCreator
    {
        private readonly ILogger _logger;

        public ShapeCreator(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        ///     Takes an CreateShapeInputCommand and creates returns an IShape object. Returns null if the command is null or the
        ///     shape is not supported.
        /// </summary>
        public IShape CreateShapeFromCommand(CreateShapeInputCommand shapeInputCommand)
        {
            if (shapeInputCommand == null)
            {
                return null;
            }

            switch (shapeInputCommand.ShapeType)
            {
                case ShapeType.Circle:
                    double radius = GetParamValue<double>(shapeInputCommand.ParamList.FirstOrDefault());
                    return GetCircle(radius);

                case ShapeType.Square:
                    double side = GetParamValue<double>(shapeInputCommand.ParamList.FirstOrDefault());
                    return GetSquare(side);

                case ShapeType.Rectangle:
                    double rectangleHeight = GetParamValue<double>(shapeInputCommand.ParamList.FirstOrDefault());
                    double rectangleWidth = GetParamValue<double>(shapeInputCommand.ParamList.Skip(1).FirstOrDefault());
                    return GetRectangle(rectangleHeight, rectangleWidth);

                case ShapeType.Triangle:
                    double triangleHeight = GetParamValue<double>(shapeInputCommand.ParamList.FirstOrDefault());
                    double triangleWidth = GetParamValue<double>(shapeInputCommand.ParamList.Skip(1).FirstOrDefault());
                    return GetTriangle(triangleHeight, triangleWidth);

                case ShapeType.Trapezoid:
                    double baseTop = GetParamValue<double>(shapeInputCommand.ParamList.FirstOrDefault());
                    double baseBottom = GetParamValue<double>(shapeInputCommand.ParamList.Skip(1).FirstOrDefault());
                    double height = GetParamValue<double>(shapeInputCommand.ParamList.Skip(2).FirstOrDefault());
                    return GetTrapezoid(baseBottom, baseTop, height);
            }

            return null;
        }

        /// <summary>
        ///     Tries to parse the parameter generic value to an usable primitive.
        /// </summary>
        private static T GetParamValue<T>(IInputParameter parameter)
        {
            InputParameter<T> param = parameter as InputParameter<T>;
            return param == null ? default(T) : param.Value;
        }

        private IShape GetSquare(double side)
        {
            IShape square = new Square
            {
                Side = side
            };
            square.CalculateSurfaceArea();

            _logger.Log($"{square.GetType().Name} created!");
            return square;
        }

        private IShape GetCircle(double radius)
        {
            IShape circle = new Circle
            {
                Radius = radius
            };
            circle.CalculateSurfaceArea();

            _logger.Log($"{circle.GetType().Name} created!");
            return circle;
        }

        private IShape GetRectangle(double height, double width)
        {
            IShape rectangle = new Rectangle
            {
                Height = height,
                Width = width
            };
            rectangle.CalculateSurfaceArea();

            _logger.Log($"{rectangle.GetType().Name} created!");
            return rectangle;
        }

        private IShape GetTriangle(double height, double width)
        {
            IShape triangle = new Triangle
            {
                Height = height,
                Width = width
            };
            triangle.CalculateSurfaceArea();

            _logger.Log($"{triangle.GetType().Name} created!");
            return triangle;
        }

        private IShape GetTrapezoid(double baseBottom, double baseTop, double height)
        {
            IShape trapezoid = new Trapezoid
            {
                BaseBottom = baseBottom,
                BaseTop = baseTop,
                Height = height
            };
            trapezoid.CalculateSurfaceArea();

            _logger.Log($"{trapezoid.GetType().Name} created!");
            return trapezoid;
        }
    }
}