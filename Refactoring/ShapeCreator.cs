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

        private IShape GetSquare(double side)
        {
            IShape square = new Square
            {
                Side = side
            };

            _logger.Log($"{square.GetType().Name} created!");
            return square;
        }

        private IShape GetCircle(double radius)
        {
            IShape circle = new Circle
            {
                Radius = radius
            };

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

            _logger.Log($"{triangle.GetType().Name} created!");
            return triangle;
        }

        public IShape CreateShapeFromCommand(IInputCommand command)
        {
            CreateShapeInputCommand shapeInputCommand = command as CreateShapeInputCommand;
            if (shapeInputCommand == null)
                return null;

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
                    break;
            }

            return null;
        }

        private static T GetParamValue<T>(IInputParameter take)
        {
            InputParameter<T> param = take as InputParameter<T>;
            return param == null ? default(T) : param.Value;
        }
    }
}