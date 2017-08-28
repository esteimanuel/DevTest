using System.ComponentModel;

namespace Refactoring.Enums
{
    /// <summary>
    /// Enums with possible params for shape
    /// </summary>
    public enum ShapeParams
    {
        [Description("Height")]
        Height,

        [Description("Width")]
        Width,

        [Description("Double")]
        Double,

        [Description("Top Base")]
        TopBase,

        [Description("Bottom Base")]
        BottomBase
    }
}