using System;

namespace Refactoring.Helper
{
    public class Comand : IComand
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }


        public object GetInstance(string type, string namespaceForType)
        {
            var strFullyQualifiedName = namespaceForType + (type).Trim();
            Type t = Type.GetType(strFullyQualifiedName);
            if (t != null)
                return Activator.CreateInstance(t);
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                t = asm.GetType(strFullyQualifiedName);
                if (type != null)
                    return Activator.CreateInstance(t);
            }
            return null;
        }

     
    }
}
