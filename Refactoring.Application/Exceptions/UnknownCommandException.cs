using System;

namespace Refactoring.Application.Exceptions
{
    public class UnknownCommandException : Exception
    {
        public UnknownCommandException()
        : base("Unknown command!")
        {
        }
    }
}