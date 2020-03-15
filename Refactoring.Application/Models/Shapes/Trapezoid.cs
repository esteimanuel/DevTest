using System;

namespace Refactoring.Application.Models.Shapes
{
    public class Trapezoid : Shape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double Height { get; set; }

        public Trapezoid(double sideA, double sideB, double height)
        {
            if (sideA <= 0 || sideB <= 0 || height <= 0)
                throw new ArgumentOutOfRangeException("Dimensions of trapezoid cannot be less or equal to 0!");

            SideA = sideA;
            SideB = sideB;
            Height = height;
        }

        public override void CalculateSurfaceArea()
        {
            Area = 0.5 * (SideA + SideB) * Height;
        }
    }
}