using Edo;

namespace Sandbox
{
    internal class Program : EdoApplication
    {
        private static void Main(string[] args)
        {
            var client = new Program();
            client.Initialize("vic485", "Sandbox");
            TestJson();
            client.Run();
        }

        private static void TestJson()
        {
            var version = new System.Version(1,0,0,0);
            var filePath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "version.json");
            var options = new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            };
            var json = System.Text.Json.JsonSerializer.Serialize(version, options);
            System.IO.File.WriteAllText(filePath, json);
        }
    }
}