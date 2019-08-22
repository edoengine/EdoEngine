using Edo;

namespace Sandbox
{
    internal class Program : EdoApplication
    {
        private static void Main(string[] args)
        {
            var client = new Program();
            client.Initialize("vic485", "Sandbox");
            
            // Testing Debug and text logger
            Debug.Log("Test message");
            var i = 2;
            Debug.Log(i);
            Debug.Log("こんにちは");
            Debug.Log(Application.PersistentDataPath);
            client.Run();
        }
    }
}