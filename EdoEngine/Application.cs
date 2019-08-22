//=============================================================================
// Application.cs
//
// Created by Victor on 2019/08/20
//=============================================================================

using System;
using System.IO;

namespace Edo
{
    /// <summary>
    /// Client application information
    /// </summary>
    public static class Application
    {
        public static string Name { get; internal set; }
        public static string Company { get; internal set; }

        public static string PersistentDataPath
        {
            get
            {
                // Windows: %AppData%\Roaming\Company\AppName\
                // Linux: ~/.config/Company/Name
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Company, Name);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                return path;
            }
        }
    }
}