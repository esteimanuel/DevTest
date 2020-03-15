using System;

namespace Refactoring.Application.Models.Shapes
{
    public class Circle : Shape
    {
        public double Radius { get; set; }
        
        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentOutOfRangeException("Radius cannot be less or equal to 0!");

            Radius = radius;
        }

        public override void CalculateSurfaceArea()
        {
            Area = Math.Round(Math.PI * (Radius * Radius), 2);
        }
    }
}