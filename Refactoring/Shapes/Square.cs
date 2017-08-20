// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// Square.cs 
// 20 / 08 / 2017

namespace Refactoring.Shapes
{
    public class Square : ShapeBase
    {
        public Square() : base(ShapeType.Square)
        {
        }

        public double Side { get; set; }

        public override void CalculateSurfaceArea()
        {
            SurfaceArea = Side * Side;
        }
    }
}