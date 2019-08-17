using System.IO;
using Edo.Utils;

namespace Edo
{
    public static class Debug
    {
        private static TextLogger _logger;
        
        internal static void Initialize()
        {
            // TODO: Proper file path
            var path = Path.Combine(Directory.GetCurrentDirectory(), "log.txt");
            _logger = new TextLogger(path, true);
        }

        /// <summary>
        /// Sends an informational message to the log
        /// </summary>
        /// <param name="message">Message to log</param>
        public static void Log(object message)
        {
            // TODO: message formatting
            _logger.Write(message.ToString());
        }
    }
}