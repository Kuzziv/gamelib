using System;
using System.Diagnostics;
using System.IO;
using YamlDotNet.Serialization;

namespace Logging.Services
{
    public class TraceLogger : ILogger
    {
        private static TraceLogger _instance;
        private static readonly object _lock = new object();

        private readonly string _logDirectory;
        private readonly ISerializer _serializer;

        public TraceLogger(string logDirectory)
        {
            _logDirectory = logDirectory;
            _serializer = new SerializerBuilder().Build();
        }

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

        public void LogInformation(string message)
        {
            LogMessage("Information", message);
        }

        public void LogWarning(string message)
        {
            LogMessage("Warning", message);
        }

        public void LogError(string message)
        {
            LogMessage("Error", message);
        }

        public void LogException(Exception exception)
        {
            LogMessage("Exception", exception.ToString());
        }

        private void LogMessage(string logLevel, string message)
        {
            try
            {
                Directory.CreateDirectory(_logDirectory);

                StackFrame frame = new StackFrame(3);
                var callingMethod = frame.GetMethod();
                var callingClass = callingMethod?.DeclaringType?.FullName;

                TraceEventCache eventCache = new TraceEventCache();
                int? eventId = eventCache?.Callstack.GetHashCode();
                string processName = Process.GetCurrentProcess().ProcessName;

                string logFilePath = Path.Combine(_logDirectory, "TraceLog.yaml");
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

                    var yaml = _serializer.Serialize(logEntry);
                    writer.WriteLine(yaml);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging message: {ex.Message}");
            }
        }
    }
}
