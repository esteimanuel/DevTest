using Refactoring.DTO;
using Refactoring.Enums;
using System.Collections.Generic;

namespace Refactoring.Shapes
{
    public class Square : IShape
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
            var side = ShapeParamList[0].ParamValue;
            return side * side;
        }
    }
}
