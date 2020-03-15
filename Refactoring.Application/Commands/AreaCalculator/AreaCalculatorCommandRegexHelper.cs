namespace Refactoring.Application.Helpers
{
    public static class AreaCalculatorCommandRegexHelper
    {
        public const string PositiveDoubleNumberPattern = @"([1-9][0-9]*(?:(\.|\,)\d+)?|0(\.|\,)\d+)";

        public static readonly string CreateSquarePattern = $"create square {PositiveDoubleNumberPattern}";
        public static readonly string CreateCirclePattern = $"create circle {PositiveDoubleNumberPattern}";
        public static readonly string CreateRectanglePattern = $"create rectangle {PositiveDoubleNumberPattern} {PositiveDoubleNumberPattern}";
        public static readonly string CreateTrianglePattern = $"create triangle {PositiveDoubleNumberPattern} {PositiveDoubleNumberPattern}";
        public static readonly string CreateTrapezoidPattern = $"create trapezoid {PositiveDoubleNumberPattern} {PositiveDoubleNumberPattern} {PositiveDoubleNumberPattern}";
    }
}