using System;
using System.IO;
using Config.Models;
using Logging.Services;
using YamlDotNet.Serialization;

namespace Config.Services
{
    /// <summary>
    /// Loads the configuration from a YAML file and sets environment variables accordingly.
    /// </summary>
    public class ConfigLoader
    {
        private readonly string _configFilePath;
        private readonly string _fileName = "config.yaml";
        private readonly IDeserializer _deserializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigLoader"/> class with the specified configuration file path.
        /// </summary>
        /// <param name="configFilePath">The path to the directory containing the configuration file.</param>
        public ConfigLoader(string configFilePath)
        {
            _configFilePath = configFilePath;
            _deserializer = new DeserializerBuilder().Build();
            LoadConfig();
        }

        /// <summary>
        /// Loads the configuration from the YAML file.
        /// </summary>
        private void LoadConfig()
        {
            try
            {
                using (StreamReader reader = File.OpenText(Path.Combine(_configFilePath, _fileName)))
                {
                    var config = _deserializer.Deserialize<AppConfig>(reader);

                    EnviromentValuesSetter(config);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading config file: {ex.Message}");
            }
        }

        /// <summary>
        /// Sets environment variables based on the loaded configuration.
        /// </summary>
        /// <param name="config">The configuration object.</param>
        private void EnviromentValuesSetter(AppConfig config)
        {
            try
            {
                if (config.TraceLevel != null)
                {
                    Environment.SetEnvironmentVariable("TRACE_LEVEL", config.TraceLevel);
                }
                if (config.LogLevel != null)
                {
                    Environment.SetEnvironmentVariable("LOG_LEVEL", config.LogLevel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error setting environment values: {ex.Message}");
            }
        }
    }
}
