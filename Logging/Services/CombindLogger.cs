using System;
using System.Collections.Generic;
using Config.Services;
using Logging.Services;

namespace Logging.Services
{
    public class CombinedLogger : ILogger
    {
        private readonly IList<ILogger> _loggers;

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

        public void LogInformation(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.LogInformation(message);
            }
        }

        public void LogWarning(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.LogWarning(message);
            }
        }

        public void LogError(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.LogError(message);
            }
        }

        public void LogException(Exception exception)
        {
            foreach (var logger in _loggers)
            {
                logger.LogException(exception);
            }
        }
    }
}
