using System;

namespace Refactoring.Application.Models.Shapes
{
    public class Rectangle : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public Rectangle(double height, double width)
        {
            if (height <= 0 || width <= 0)
            {
                throw new ArgumentOutOfRangeException("Dimensions of rectangle cannot be less or equal to 0!");
            }

            Height = height;
            Width = width;
        }

        public override void CalculateSurfaceArea()
        {
            Area = Height * Width;
        }
    }
}