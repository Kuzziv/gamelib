using System;
using System.IO;
using YamlDotNet.Serialization;

namespace Logging.Services
{
    public class YamlFileLogger : ILogger
    {
        private static YamlFileLogger _instance;
        private static readonly object _lock = new object();

        private readonly string _logDirectory;
        private readonly IDeserializer _deserializer;
        private readonly ISerializer _serializer;

        public YamlFileLogger(string logDirectory)
        {
            _logDirectory = logDirectory;
            _deserializer = new DeserializerBuilder().Build();
            _serializer = new SerializerBuilder().Build();
        }

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

        public void LogInformation(string message)
        {
            Log("Information", message);
        }

        public void LogWarning(string message)
        {
            Log("Warning", message);
        }

        public void LogError(string message)
        {
            Log("Error", message);
        }

        public void LogException(Exception exception)
        {
            Log("Exception", exception.ToString());
        }

        private void Log(string logLevel, string message)
        {
            try
            {
                Directory.CreateDirectory(_logDirectory);

                string logFilePath = Path.Combine(_logDirectory, $"{logLevel}.yaml");
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    var logEntry = new { Level = logLevel, Message = message, Timestamp = DateTime.Now };
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
