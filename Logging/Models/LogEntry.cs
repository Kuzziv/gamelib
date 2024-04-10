using System;

namespace Logging.Models
{
    // Represents a log entry in YAML format
    public class LogEntry
    {
        public DateTime Timestamp { get; }
        public LogLevel LogLevel { get; }
        public string CategoryName { get; }
        public string Message { get; }

        public LogEntry(DateTime timestamp, LogLevel logLevel, string categoryName, string message)
        {
            Timestamp = timestamp;
            LogLevel = logLevel;
            CategoryName = categoryName;
            Message = message;
        }
    }
}