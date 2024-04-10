using System.IO;
using Config.Models;
using Logging.Services;
using YamlDotNet.Serialization;

namespace Config.Services
{
    public class ConfigLoader
    {
        private readonly string _configFilePath;
        private readonly string _fileName = "config.yaml";
        private readonly IDeserializer _deserializer;

        public ConfigLoader(string configFilePath)
        {
            _configFilePath = configFilePath;
            _deserializer = new DeserializerBuilder().Build();
            LoadConfig();
        }

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
                throw new Exception($"Error setting enviroment values: {ex.Message}");
            }
        }


    }
}
