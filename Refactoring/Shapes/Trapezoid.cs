using Refactoring.DTO;
using Refactoring.Enums;
using System.Collections.Generic;

namespace Refactoring.Shapes
{
    public class Trapezoid : IShape
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
            _shapeParamList.Add(new ShapeParam() { ParamName = ShapeParams.Height.ToString() });
            _shapeParamList.Add(new ShapeParam() { ParamName = ShapeParams.BottomBase.ToString() });
            _shapeParamList.Add(new ShapeParam() { ParamName = ShapeParams.TopBase.ToString() });
        }

        public double CalculateSurfaceArea()
        {
            var height = ShapeParamList[0].ParamValue;
            var bottomBase = ShapeParamList[1].ParamValue;
            var topBase = ShapeParamList[2].ParamValue;
            return ((bottomBase + topBase) / 2) * height;
        }
    }
}