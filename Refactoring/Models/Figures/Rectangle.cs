namespace Refactoring.Models.Figures
{
    public class Rectangle : Figure
    {
        public double Height { get;  }

        public double Width { get;  }

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public override double CalculateSurfaceArea()
        {
            return Height * Width;
        }
    }
}