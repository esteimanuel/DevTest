using Refactoring.DTO;
using Refactoring.Enums;
using System.Collections.Generic;

namespace Refactoring.Shapes
{
    class Triangle : IShape
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
            _shapeParamList.Add(new ShapeParam() { ParamName = ShapeParams.Width.ToString() });
        }

        public double CalculateSurfaceArea()
        {
            var height = ShapeParamList[0].ParamValue;
            var width = ShapeParamList[1].ParamValue;
            return 0.5 * (height * width);
        }
    }
}