using Config.Services;
using System;
using System.Collections.Generic;

namespace Logging.Services
{
    /// <summary>
    /// Logger that combines multiple loggers and forwards log messages to each of them.
    /// </summary>
    public class CombinedLogger : ILogger
    {
        private readonly IList<ILogger> _loggers;

        /// <summary>
        /// Initializes a new instance of the <see cref="CombinedLogger"/> class with the specified log directory.
        /// </summary>
        /// <param name="logDirectory">The directory where log files are stored.</param>
        public CombinedLogger(string logDirectory)
        {
            string traceLevel = Environment.GetEnvironmentVariable("TRACE_LEVEL") ?? "Information";
            string logLevel = Environment.GetEnvironmentVariable("LOG_LEVEL") ?? "Information";

            _loggers = new List<ILogger>
            {
                new LogLevelFilter(new YamlFileLogger(logDirectory), logLevel),
                new LogLevelFilter(new TraceLogger(logDirectory), traceLevel)
            };
        }

        /// <summary>
        /// Logs an information message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogInformation(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.LogInformation(message);
            }
        }

        /// <summary>
        /// Logs a warning message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogWarning(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.LogWarning(message);
            }
        }

        /// <summary>
        /// Logs an error message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogError(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.LogError(message);
            }
        }

        /// <summary>
        /// Logs an exception.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        public void LogException(Exception exception)
        {
            foreach (var logger in _loggers)
            {
                logger.LogException(exception);
            }
        }
    }
}
