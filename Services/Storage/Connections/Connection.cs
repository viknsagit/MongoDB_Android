using System.Text.Json.Serialization;

namespace MongoDB_Android.Services.Storage.Connections
{
    public class Connection
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("UnixTimeAdd")]
        public string UnixTimeAdd { get; set; }

        [JsonPropertyName("Url")]
        public string Url { get; set; }
    }
}