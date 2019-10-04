using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Edo.Vfs
{
    public class TextureManager
    {
        static TextureManager()
        {
            FileSystemManager.AddPath(".\\GameData\\Textures");
        }

        // for testing
        public static void Save<T>(T data)
        {
            var guid = Guid.NewGuid().ToString();
            using var fs = File.Create(Path.Combine(FileSystemManager.GetFirstPath(), guid));
            new BinaryFormatter().Serialize(fs, data);
        }

        public static T Load<T>(string id)
        {
            var path = FileSystemManager.FindFile(id);
            if (string.IsNullOrWhiteSpace(path))
            {
                Debug.LogError($"Missing texture with id {id}");
                return default;
            }

            using var fs = File.OpenRead(path);
            return (T) new BinaryFormatter().Deserialize(fs);
        }
    }
}