using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Edo.Vfs
{
    public static class FileSystemManager
    {
        private static readonly string DataPath = Path.Combine(Directory.GetCurrentDirectory(), "GameData");

        public static T Load<T>(string fileId)
        {
            using var fs = File.OpenRead(Path.Combine(DataPath, fileId));
            return (T) new BinaryFormatter().Deserialize(fs);
        }
    }
}