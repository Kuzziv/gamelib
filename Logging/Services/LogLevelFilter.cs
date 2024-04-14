using System;
using Logging.Services;

namespace Config.Services
{
    /// <summary>
    /// A logger that filters log messages based on the specified log level.
    /// </summary>
    public class LogLevelFilter : ILogger
    {
        private readonly ILogger _logger;
        private readonly string _logLevel;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogLevelFilter"/> class.
        /// </summary>
        /// <param name="logger">The logger to filter messages for.</param>
        /// <param name="logLevel">The log level to filter messages by.</param>
        public LogLevelFilter(ILogger logger, string logLevel)
        {
            _logger = logger;
            _logLevel = logLevel;
        }

        /// <summary>
        /// Logs an information message if the log level allows it.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogInformation(string message)
        {
            if (_logLevel == "Information")
            {
                _logger.LogInformation(message);
            }
        }

        /// <summary>
        /// Logs a warning message if the log level allows it.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogWarning(string message)
        {
            if (_logLevel == "Information" || _logLevel == "Warning")
            {
                _logger.LogWarning(message);
            }
        }

        /// <summary>
        /// Logs an error message if the log level allows it.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogError(string message)
        {
            if (_logLevel == "Information" || _logLevel == "Warning" || _logLevel == "Error")
            {
                _logger.LogError(message);
            }
        }

        /// <summary>
        /// Logs an exception.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        public void LogException(Exception exception)
        {
            _logger.LogException(exception);
        }
    }
}
