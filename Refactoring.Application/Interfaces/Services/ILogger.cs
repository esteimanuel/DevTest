using System;

namespace Refactoring.Application.Interfaces.Services
{
    public interface ILogger
    {
        void Log(string text);

        void LogError(string errorMessage);

        void LogError(Exception ex);
    }
}