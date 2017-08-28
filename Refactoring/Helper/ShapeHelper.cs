using Refactoring.Shapes;

namespace Refactoring.Helper
{
    public class ShapeHelper : Comand
    {
        private const string shapeNamespace = "Refactoring.Shapes.";

        /// <summary>
        /// Returns instance of specific shape with all needed params
        /// </summary>
        public IShape GetShapeInstance(string shape)
        {
            var shapeInstance = (IShape)GetInstance(shape, shapeNamespace);
            shapeInstance.InitParams();
            return shapeInstance;
        }
    }
}
