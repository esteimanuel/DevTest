// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// Circle.cs 
// 20 / 08 / 2017

using System;
using Refactoring.Enums;

namespace Refactoring.DataModels.Shapes
{
    public class Circle : ShapeBase
    {
        public Circle() : base(ShapeType.Circle)
        {
        }

        public double Radius { get; set; }

        public override void CalculateSurfaceArea()
        {
            SurfaceArea = Math.Round(Math.PI * (Radius * Radius), 2);
        }
    }
}