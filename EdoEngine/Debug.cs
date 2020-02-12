using System;
using System.IO;

namespace EdoEngine
{
    public static class Debug
    {
        private static readonly string FilePath;
        private static readonly object FileLock = new object();

        static Debug()
        {
            var logFolder = Path.Combine(Application.AppPath, "logs");
            if (!Directory.Exists(logFolder))
                Directory.CreateDirectory(logFolder);

            FilePath = Path.Combine(logFolder, $"{DateTime.Now:yyyy-MM-dd-HH-mm}.log");
        }

        public static void LogInfo(object message)
        {
            var logMessage = $"[DEBUG] {message}";
            Console.WriteLine(logMessage);
            WriteToFile(logMessage);
        }

        private static void WriteToFile(string message)
        {
            lock (FileLock)
            {
                using var writer = File.AppendText(FilePath);
                writer.WriteLine(message);
            }
        }
    }
}