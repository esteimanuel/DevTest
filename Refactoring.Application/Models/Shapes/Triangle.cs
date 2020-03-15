using System;

namespace Refactoring.Application.Models.Shapes
{
    public class Triangle : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public Triangle(double height, double width)
        {
            if (height <= 0 || width <= 0)
                throw new ArgumentOutOfRangeException("Dimensions of triangle cannot be less or equal to 0!");

            Height = height;
            Width = width;
        }

        public override void CalculateSurfaceArea()
        {
            Area = 0.5 * (Height * Width);
        }
    }
}