// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// Triangle.cs 
// 20 / 08 / 2017

namespace Refactoring.Shapes
{
    public class Triangle : IShape
    {
        public double Height { get; set; }

        public double Width { get; set; }

        public double CalculateSurfaceArea()
        {
            return 0.5 * (Height * Width);
        }

    }
}