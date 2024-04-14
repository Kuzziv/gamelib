using System;
using System.Diagnostics;
using System.IO;
using YamlDotNet.Serialization;

namespace Logging.Services
{
    /// <summary>
    /// A logger that writes log messages to a YAML file using the Trace mechanism.
    /// </summary>
    public class TraceLogger : ILogger
    {
        private static TraceLogger _instance;
        private static readonly object _lock = new object();

        private readonly string _logDirectory;
        private readonly ISerializer _serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="TraceLogger"/> class.
        /// </summary>
        /// <param name="logDirectory">The directory where log files will be stored.</param>
        public TraceLogger(string logDirectory)
        {
            _logDirectory = logDirectory;
            _serializer = new SerializerBuilder().Build();
        }

        /// <summary>
        /// Gets a singleton instance of the TraceLogger.
        /// </summary>
        /// <param name="logDirectory">The directory where log files will be stored.</param>
        /// <returns>A singleton instance of the TraceLogger.</returns>
        public static TraceLogger GetInstance(string logDirectory)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new TraceLogger(logDirectory);
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
            LogMessage("Information", message);
        }

        /// <summary>
        /// Logs a warning message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogWarning(string message)
        {
            LogMessage("Warning", message);
        }

        /// <summary>
        /// Logs an error message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogError(string message)
        {
            LogMessage("Error", message);
        }

        /// <summary>
        /// Logs an exception.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        public void LogException(Exception exception)
        {
            LogMessage("Exception", exception.ToString());
        }

        /// <summary>
        /// Logs a message with the specified log level.
        /// </summary>
        /// <param name="logLevel">The level of the log message (e.g., Information, Warning, Error).</param>
        /// <param name="message">The message to log.</param>
        private void LogMessage(string logLevel, string message)
        {
            try
            {
                // Create the log directory if it doesn't exist
                Directory.CreateDirectory(_logDirectory);

                // Get information about the calling method
                StackFrame frame = new StackFrame(3);
                var callingMethod = frame.GetMethod();
                var callingClass = callingMethod?.DeclaringType?.FullName;

                // Get event information for the log message
                TraceEventCache eventCache = new TraceEventCache();
                int? eventId = eventCache?.Callstack.GetHashCode();
                string processName = Process.GetCurrentProcess().ProcessName;

                // Determine the log file path
                string logFilePath = Path.Combine(_logDirectory, "TraceLog.yaml");

                // Write the log message to the YAML log file
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    var logEntry = new
                    {
                        Message = message,
                        CallerClass = callingClass,
                        CallerMethod = callingMethod?.Name,
                        EventId = eventId,
                        ProcessName = processName,
                        Timestamp = DateTime.Now
                    };

                    // Serialize the log entry to YAML format
                    var yaml = _serializer.Serialize(logEntry);
                    // Write the serialized YAML to the log file
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
