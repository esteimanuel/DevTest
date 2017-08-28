using System;

namespace Refactoring.Helper
{
    public interface IComand
    {
        void Write(string message);

        string ReadLine();

        ConsoleKeyInfo ReadKey();

        /// <summary>
        /// Returns specific property of specific object
        /// </summary>
        object GetPropValue(object src, string propName);

        /// <summary>
        /// Returns object of instance of the specific type
        /// </summary>
        object GetInstance(string shapeType, string shapeNamespace);
    }
}
