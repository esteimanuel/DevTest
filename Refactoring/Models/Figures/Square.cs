namespace Refactoring.Models.Figures
{
    public class Square : Figure
    {
        public double Side { get;  }

        public Square(double side)
        {
            Side = side;
        }

        public override double CalculateSurfaceArea()
        {
            return Side * Side;
        }
    }
}