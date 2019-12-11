using System.Runtime.Serialization.Formatters.Binary;
using Edo;
using Edo.Mathematics;

namespace Sandbox
{
    internal class Program : EdoApplication
    {
        private static void Main(string[] args)
        {
            var client = new Program();
            client.Initialize("vic485", "Sandbox");
            Debug.Log(EdoMath.Epsilon);
            //TestJson();
            //TestBinary();
            client.Run();
        }

        /*private static void TestJson()
        {
            var vec = new Vector2(2, 4);
            Debug.Log(vec.GetHashCode());
            var filePath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "vector.json");
            var options = new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            };
            var json = System.Text.Json.JsonSerializer.Serialize(vec, options);
            System.IO.File.WriteAllText(filePath, json);
        }

        private static void TestBinary()
        {
            var vec = new Vector2(2, 4);
            var filePath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "vector.dat");
            using var fs = System.IO.File.Create(filePath);
            new BinaryFormatter().Serialize(fs, vec);
        }*/
    }
}