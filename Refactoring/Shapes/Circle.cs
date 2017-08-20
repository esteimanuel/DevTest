// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// Circle.cs 
// 20 / 08 / 2017

using System;

namespace Refactoring.Shapes
{
    public class Circle : IShape
    {
        public double Radius { get; set; }

        public double CalculateSurfaceArea()
        {
            return Math.Round(Math.PI * (Radius * Radius), 2);
        }
    }
}