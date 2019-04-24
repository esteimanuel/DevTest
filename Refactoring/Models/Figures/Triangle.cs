namespace Refactoring.Models.Figures
{
    public class Triangle : Figure
    {
        public double Height { get; }

        public double Width { get; }

        public Triangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public override double CalculateSurfaceArea()
        {
            return 0.5 * (Height * Width);
        }
    }
}