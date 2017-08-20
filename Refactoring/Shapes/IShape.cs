// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// IShape.cs 
// 20 / 08 / 2017

namespace Refactoring.Shapes
{
    public interface IShape
    {
        ShapeType ShapeType { get; }
        double SurfaceArea { get; }

        void CalculateSurfaceArea();
        string GetShapeName();
    }
}