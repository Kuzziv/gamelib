using System;
using System.IO;
using YamlDotNet.Serialization;

namespace Logging.Services
{
    /// <summary>
    /// Provides logging functionality by writing log messages to YAML files.
    /// </summary>
    public class YamlFileLogger : ILogger
    {
        private static YamlFileLogger _instance;
        private static readonly object _lock = new object();

        private readonly string _logDirectory;
        private readonly IDeserializer _deserializer;
        private readonly ISerializer _serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="YamlFileLogger"/> class with the specified log directory.
        /// </summary>
        /// <param name="logDirectory">The directory where log files will be stored.</param>
        private YamlFileLogger(string logDirectory)
        {
            _logDirectory = logDirectory;
            _deserializer = new DeserializerBuilder().Build();
            _serializer = new SerializerBuilder().Build();
        }

        /// <summary>
        /// Gets the singleton instance of the <see cref="YamlFileLogger"/> class.
        /// </summary>
        /// <param name="logDirectory">The directory where log files will be stored.</param>
        /// <returns>The singleton instance of the <see cref="YamlFileLogger"/> class.</returns>
        public static YamlFileLogger GetInstance(string logDirectory)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new YamlFileLogger(logDirectory);
                }
                return _instance;
            }
        }

        /// <summary>
        /// Logs an information message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogInformation(string message)
        {
            Log("Information", message);
        }

        /// <summary>
        /// Logs a warning message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogWarning(string message)
        {
            Log("Warning", message);
        }

        /// <summary>
        /// Logs an error message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogError(string message)
        {
            Log("Error", message);
        }

        /// <summary>
        /// Logs an exception.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        public void LogException(Exception exception)
        {
            Log("Exception", exception.ToString());
        }

        /// <summary>
        /// Writes a log message to the appropriate YAML log file.
        /// </summary>
        /// <param name="logLevel">The level of the log message.</param>
        /// <param name="message">The message to log.</param>
        private void Log(string logLevel, string message)
        {
            try
            {
                // Create the log directory if it doesn't exist
                Directory.CreateDirectory(_logDirectory);

                // Determine the log file path based on the log level
                string logFilePath = Path.Combine(_logDirectory, $"{logLevel}.yaml");

                // Write the log message to the YAML log file
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    var logEntry = new { Level = logLevel, Message = message, Timestamp = DateTime.Now };
                    var yaml = _serializer.Serialize(logEntry);
                    writer.WriteLine(yaml);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during logging
                Console.WriteLine($"Error logging message: {ex.Message}");
            }
        }
    }
}
