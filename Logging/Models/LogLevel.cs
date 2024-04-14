namespace Logging.Models
{
    /// <summary>
    /// Enumeration representing log levels.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Debug level for detailed debugging information.
        /// </summary>
        Debug,

        /// <summary>
        /// Information level for general information messages.
        /// </summary>
        Information,

        /// <summary>
        /// Warning level for potential issues that may need attention.
        /// </summary>
        Warning,

        /// <summary>
        /// Error level for errors that occurred but did not prevent the application from functioning.
        /// </summary>
        Error,

        /// <summary>
        /// Critical level for critical errors that require immediate attention and may cause the application to crash.
        /// </summary>
        Critical
    }
}
