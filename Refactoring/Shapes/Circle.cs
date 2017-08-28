using System;
using System.Collections.Generic;
using Refactoring.Enums;
using Refactoring.DTO;

namespace Refactoring.Shapes
{
    public class Circle : IShape
    {
        List<ShapeParam> _shapeParamList = new List<ShapeParam>();

        public List<ShapeParam> ShapeParamList
        {
            get
            {
                return _shapeParamList;
            }

            set
            {
                _shapeParamList = value;
            }
        }

        public void InitParams()
        {
            _shapeParamList.Add(new ShapeParam() { ParamName = ShapeParams.Double.ToString() });
        }

        public double CalculateSurfaceArea()
        {
            var radius = ShapeParamList[0].ParamValue;
            return Math.Round(Math.PI * (radius * radius), 2);
        }
    }
}
