using System.IO;
using Config.Models;
using Logging.Services;
using YamlDotNet.Serialization;

namespace Config.Services
{
    public class LogLevelFilter : ILogger
    {
        private readonly ILogger _logger;
        private readonly string _logLevel;

        public LogLevelFilter(ILogger logger, string logLevel)
        {
            _logger = logger;
            _logLevel = logLevel;
        }

        public void LogInformation(string message)
        {
            if (_logLevel == "Information")
            {
                _logger.LogInformation(message);
            }
        }

        public void LogWarning(string message)
        {
            if (_logLevel == "Information" || _logLevel == "Warning")
            {
                _logger.LogWarning(message);
            }
        }

        public void LogError(string message)
        {
            if (_logLevel == "Information" || _logLevel == "Warning" || _logLevel == "Error")
            {
                _logger.LogError(message);
            }
        }

        public void LogException(Exception exception)
        {
            _logger.LogException(exception);
        }
    }
}
