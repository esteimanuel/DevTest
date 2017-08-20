// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// Rectangle.cs 
// 20 / 08 / 2017

using Refactoring.Enums;

namespace Refactoring.DataModels.Shapes
{
    public class Rectangle : ShapeBase
    {
        public Rectangle() : base(ShapeType.Rectangle)
        {
        }

        public double Height { get; set; }

        public double Width { get; set; }

        public override void CalculateSurfaceArea()
        {
            SurfaceArea = Height * Width;
        }
    }
}