using System;


namespace Config.Models
{
    /// <summary>
    /// Configuration for the application.
    /// </summary>
    public class AppConfig
    {
        public string? TraceLevel { get; set; }

        public string? LogLevel { get; set; }
    }
}