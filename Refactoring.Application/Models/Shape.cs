namespace Refactoring.Application.Models
{
    public abstract class Shape
    {
        public double? Area { get; protected set; }

        public abstract void CalculateSurfaceArea();

        public override string ToString()
        {
            return $"{GetType().Name} surface area is {(Area.HasValue ? Area.ToString() : "unknown")}";
        }
    }
}