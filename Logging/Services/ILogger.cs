using System;

namespace Logging.Services
{
    /// <summary>
    /// Interface for logging messages.
    /// </summary>
    public interface ILogger
    {
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(string message);
        void LogException(Exception exception);
    }
}