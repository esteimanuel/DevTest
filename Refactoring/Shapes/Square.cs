// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// Square.cs 
// 20 / 08 / 2017

namespace Refactoring.Shapes
{
    public class Square : IShape
    {
        public double Side { get; set; }

        public double CalculateSurfaceArea()
        {
            return Side * Side;
        }

    }
}