// Copyright © 2017 by Alexander Streng
// All rights reserved. 
// 
// ShapeBase.cs 
// 20 / 08 / 2017

using Refactoring.Enums;
using Refactoring.Extensions;

namespace Refactoring.DataModels.Shapes
{
    public abstract class ShapeBase : IShape
    {
        protected ShapeBase(ShapeType type)
        {
            ShapeType = type;
        }

        public ShapeType ShapeType { get; }

        public double SurfaceArea { get; set; }

        public abstract void CalculateSurfaceArea();

        public string GetShapeName()
        {
            return ShapeType.GetDescription();
        }

        public override string ToString()
        {
            return $"{GetShapeName()} surface area is {SurfaceArea}";
        }
    }
}