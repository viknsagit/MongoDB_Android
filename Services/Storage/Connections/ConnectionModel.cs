using CommunityToolkit.Mvvm.ComponentModel;

using System.Text.Json.Serialization;

namespace MongoDB_Android.Services.Storage.Connections
{
    public partial class ConnectionModel : ObservableObject
    {
        [JsonPropertyName("Name")]
        [ObservableProperty]
        public string name;

        [JsonPropertyName("UnixTimeAdd")]
        [ObservableProperty]
        public long unixTimeAdd;

        [JsonPropertyName("Url")]
        [ObservableProperty]
        public string url;
    }
}