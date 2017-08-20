// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// Rectangle.cs 
// 20 / 08 / 2017

namespace Refactoring.Shapes
{
    public class Rectangle : IShape
    {
        public double Height { get; set; }

        public double Width { get; set; }

        public double CalculateSurfaceArea()
        {
            return Height * Width;
        }
    }

}