// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// Triangle.cs 
// 20 / 08 / 2017

using Refactoring.Enums;

namespace Refactoring.DataModels.Shapes
{
    public class Triangle : ShapeBase
    {
        public Triangle() : base(ShapeType.Triangle)
        {
        }

        public double Height { get; set; }

        public double Width { get; set; }

        public override void CalculateSurfaceArea()
        {
            SurfaceArea = 0.5 * (Height * Width);
        }
    }
}