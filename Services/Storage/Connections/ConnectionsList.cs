using System.Text.Json.Serialization;

namespace MongoDB_Android.Services.Storage.Connections
{
    public class ConnectionsList
    {
        [JsonPropertyName("Connections")]
        public List<string> Connections { get; set; }
    }
}