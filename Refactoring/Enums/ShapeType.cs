// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// ShapeType.cs 
// 20 / 08 / 2017

using System.ComponentModel;

namespace Refactoring.Enums
{
    public enum ShapeType
    {
        [Description("Circle")] Circle,

        [Description("Square")] Square,

        [Description("Rectangle")] Rectangle,

        [Description("Triangle")] Triangle,

        [Description("Trapezoid")] Trapezoid
    }
}