using Edo;

namespace Sandbox
{
    internal class Program : EdoApplication
    {
        private static void Main(string[] args)
        {
            var client = new Program();
            client.Initialize("vic485", "Sandbox");
            client.Run();
        }
    }
}