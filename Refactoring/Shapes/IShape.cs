using Refactoring.DTO;
using System.Collections.Generic;

namespace Refactoring.Shapes
{
    public interface IShape
    {
        /// <summary>
        ///List of params that are needed for calculation serface area of the shape
        /// </summary>
        List<ShapeParam> ShapeParamList
        {
            get;
            set;
        }

        /// <summary>
        ///Sets params that are needed for the shape
        /// </summary>
        void InitParams();

        /// <summary>
        ///Calculates surface area for the shape
        /// </summary>
        double CalculateSurfaceArea();
    }
}
