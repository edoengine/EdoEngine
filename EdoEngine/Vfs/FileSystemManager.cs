using System.Collections.Generic;
using System.IO;

namespace Edo.Vfs
{
    public class FileSystemManager
    {
        private static List<string> _paths = new List<string>();

        // Add a path to possible file places. parameter path: A full path to search e.g. C:\MyGame\Data
        public static void AddPath(string path)
        {
            var absolutePath = Path.GetFullPath(path);
            if (!Directory.Exists(absolutePath) || _paths.Contains(absolutePath))
                return;
            
            _paths.Add(absolutePath);
        }
        
        // for testing
        public static string GetFirstPath() => _paths[0];

        // Searches for a file, and returns it's path
        public static string FindFile(string id)
        {
            foreach (var path in _paths)
            {
                var current = Path.Combine(path, id);
                if (File.Exists(current))
                    return current;
            }

            return null;
        }
    }
}