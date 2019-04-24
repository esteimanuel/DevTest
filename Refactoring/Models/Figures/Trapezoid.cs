namespace Refactoring.Models.Figures
{
    public class Trapezoid : Figure
    {
        public double Side1 { get; }
        public double Side2 { get; }
        public double Height { get; }

        public Trapezoid(double side1, double side2, double height)
        {
            Side1 = side1;
            Side2 = side2;
            Height = height;
        }

        public override double CalculateSurfaceArea()
        {
            return 0.5 * (Side1 + Side2) * Height;
        }
    }
}