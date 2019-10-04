using System.Text.Json;

namespace Edo
{
    public class JsonUtil
    {
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        public string ToJson<T>(T obj)
            => JsonSerializer.Serialize(obj, _options);
    }
}