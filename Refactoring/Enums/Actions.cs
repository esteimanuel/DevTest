using System.ComponentModel;

namespace Refactoring.Enums
{
    /// <summary>
    /// Enums with possible actions
    /// </summary>
    public enum Actions
    {
        [Description("create a new")]
        Create,

        [Description("calulate the surface areas of the created shapes")]
        Calculate,

        [Description("print the calculated surface areas")]
        Print,

        [Description("reset")]
        Reset,

        [Description("exit the loop")]
        Exit
    }
}