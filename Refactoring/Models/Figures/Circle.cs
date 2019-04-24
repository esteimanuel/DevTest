using System;

namespace Refactoring.Models.Figures
{
    public class Circle : Figure
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateSurfaceArea()
        {
            return Math.Round(Math.PI * (Radius * Radius), 2);
        }
    }
}