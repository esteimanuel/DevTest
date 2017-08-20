// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// Trapezoid.cs 
// 20 / 08 / 2017

using System;
using Refactoring.Enums;

namespace Refactoring.DataModels.Shapes
{
    public class Trapezoid : ShapeBase
    {
        public double Height { get; set; }

        public double BaseTop { get; set; }

        public double BaseBottom { get; set; }

        public Trapezoid() : base(ShapeType.Trapezoid)
        {
        }

        public override void CalculateSurfaceArea()
        {
            SurfaceArea = ((BaseBottom + BaseTop) / 2) * Height;
        }
    }
}