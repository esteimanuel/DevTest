using System;

namespace Refactoring.Application.Models.Shapes
{
    public class Square : Rectangle
    {
        public Square(double side) : base(side, side)
        {
            if (side <= 0)
                throw new ArgumentOutOfRangeException("Side cannot be less or equal to 0!");
            
            Height = side;
            Width = side;
        }
    }
}