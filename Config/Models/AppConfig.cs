using System;


namespace Config.Models
{
    /// <summary>
    /// Configuration for the application.
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// Gets or sets the trace level for logging.
        /// </summary>
        public string? TraceLevel { get; set; }

        /// <summary>
        /// Gets or sets the log level for logging.
        /// </summary>
        public string? LogLevel { get; set; }
    }
}