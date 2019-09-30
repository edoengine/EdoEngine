//=============================================================================
// Debug.cs
//
// Created by Victor on 2019/08/17
//=============================================================================

using System.IO;
using Edo.Utils;

namespace Edo
{
    public static class Debug
    {
        private static TextLogger _logger;
        
        static Debug()
        {
            // TODO: Proper file path
            var path = Path.Combine(Application.PersistentDataPath, "log.txt");
            _logger = new TextLogger(path, true);
        }

        /// <summary>
        /// Sends an informational message to the log
        /// </summary>
        /// <param name="message">Message to log</param>
        public static void Log(object message)
            => _logger.Write(FormatMessage(message.ToString(), "INFO"));

        /// <summary>
        /// Sends an error message to the log
        /// </summary>
        /// <param name="message">Error message to log</param>
        public static void LogError(object message)
            => _logger.Write(FormatMessage(message.ToString(), "ERROR"));

        /// <summary>
        /// Sends a warning message to the log
        /// </summary>
        /// <param name="message">Warning message to log</param>
        public static void LogWarning(object message)
            => _logger.Write(FormatMessage(message.ToString(), "WARN"));

        private static string FormatMessage(string message, string type)
            => $"[{type}] {message}";

        internal static void RawMessage(string message)
            => _logger.Write(message);
    }
}