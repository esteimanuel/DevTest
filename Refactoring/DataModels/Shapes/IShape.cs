// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// IShape.cs 
// 20 / 08 / 2017

using Refactoring.Enums;

namespace Refactoring.DataModels.Shapes
{
    public interface IShape
    {
        /// <summary>
        /// The type of this shape.
        /// </summary>
        ShapeType ShapeType { get; }

        /// <summary>
        /// The total surface area of this shape. 
        /// </summary>
        double SurfaceArea { get; }

        /// <summary>
        /// Method which (re)calculates the total surface area of this shape
        /// </summary>
        void CalculateSurfaceArea();

        /// <summary>
        /// Returns the name of this shape
        /// </summary>
        string GetShapeName();
    }
}