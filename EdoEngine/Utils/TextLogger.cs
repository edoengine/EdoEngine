//=============================================================================
// TextLogger.cs
//
// Created by Victor on 2019/08/17
//=============================================================================

using System;
using System.IO;
using System.Text;

namespace Edo.Utils
{
    internal class TextLogger
    {
        // Default Japanese encoding is UTF8 w/o BOM
        private Encoding _encoding = new UTF8Encoding(false);

        private string _filePath;
        
        /// <summary>
        /// Constructs a new text logger
        /// </summary>
        /// <param name="filePath">Device path and file name of the log file. e.g. c:\my_game\log.txt</param>
        /// <param name="rotate">Whether to backup the previous version of this file (if it exists)</param>
        internal TextLogger(string filePath, bool rotate = false)
        {
            _filePath = filePath;
            
            // TODO: Flip or remove this if we don't need to do anything else on construction
            if (!rotate)
                return;

            if (!File.Exists(filePath))
                return;

            var newPath = $"{Path.ChangeExtension(filePath, null)}-prev.txt";
            File.Move(filePath, newPath, true);
        }

        /// <summary>
        /// Write a message to the console and log file
        /// </summary>
        /// <param name="message">Message to log</param>
        internal void Write(string message)
        {
            Console.WriteLine(message);
            File.AppendAllText(_filePath, message + Environment.NewLine, _encoding);
        }
    }
}