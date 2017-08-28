using System.ComponentModel;

namespace Refactoring.Enums
{
    /// <summary>
    /// Enums with possible shapes
    /// </summary>
    public enum ShapeType
    {
        [Description("Square")]
        Square,

        [Description("Circle")]
        Circle,

        [Description("Rectangle")]
        Rectangle,

        [Description("Triangle")]
        Triangle,

        [Description("Trapezoid")]
        Trapezoid
    }
}