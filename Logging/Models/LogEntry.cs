using System;

namespace Logging.Models
{
    /// <summary>
    /// Represents a log entry in YAML format.
    /// </summary>
    public class LogEntry
    {
        /// <summary>
        /// Gets the timestamp of the log entry.
        /// </summary>
        public DateTime Timestamp { get; }

        /// <summary>
        /// Gets the log level of the log entry.
        /// </summary>
        public LogLevel LogLevel { get; }

        /// <summary>
        /// Gets the category name of the log entry.
        /// </summary>
        public string CategoryName { get; }

        /// <summary>
        /// Gets the message content of the log entry.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogEntry"/> class with the specified parameters.
        /// </summary>
        /// <param name="timestamp">The timestamp of the log entry.</param>
        /// <param name="logLevel">The log level of the log entry.</param>
        /// <param name="categoryName">The category name of the log entry.</param>
        /// <param name="message">The message content of the log entry.</param>
        public LogEntry(DateTime timestamp, LogLevel logLevel, string categoryName, string message)
        {
            Timestamp = timestamp;
            LogLevel = logLevel;
            CategoryName = categoryName;
            Message = message;
        }
    }
}
