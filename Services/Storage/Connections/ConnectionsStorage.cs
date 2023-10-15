using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace MongoDB_Android.Services.Storage.Connections
{
    public class ConnectionsStorage
    {
        private readonly string _storage;
        private readonly string _cache;

        public ConnectionsStorage()
        {
            _storage = FileSystem.Current.AppDataDirectory;
            _cache = FileSystem.Current.CacheDirectory;
        }

        public async Task CreateStorageAsync()
        {
            if (File.Exists(_storage + "Connections.json"))
            {
                await LogFileAsync();
                return;
            }

            var json = JsonSerializer.Serialize(new ConnectionsList() { Connections = new() });
            byte[] buffer = Encoding.Default.GetBytes(json);

            using FileStream fileStream = File.Create(_storage + "Connections.json");
            await fileStream.WriteAsync(buffer);
            fileStream.Close();
            await LogFileAsync();
        }

        private async Task UpdateConnectionsListAsync(ConnectionsList list)
        {
            var json = JsonSerializer.Serialize(list);
            byte[] buffer = Encoding.Default.GetBytes(json);

            using FileStream fileStream = File.OpenWrite(_storage + "Connections.json");
            await fileStream.WriteAsync(buffer);
            fileStream.Close();
            await LogFileAsync();
        }

        public async Task AddNewConnectionToStorageAsync(ConnectionModel connection)
        {
            var json = await GetConnectionsListAsync();
            json.Connections!.Add(connection);
            await UpdateConnectionsListAsync(json);
            await LogFileAsync();
        }

        private async Task LogFileAsync()
        {
            var text = await File.ReadAllTextAsync(_storage + "Connections.json");
            Debug.WriteLine("File text: " + text);
        }

        public async Task<ConnectionsList> GetConnectionsListAsync()
        {
            FileStream stream = File.OpenRead(_storage + "Connections.json");
            var list = await JsonSerializer.DeserializeAsync<ConnectionsList>(stream);
            stream.Close();
            return list!;
        }

        public async Task ResetConnectionsAsync()
        {
            File.Delete(_storage + "Connections.json");
            await CreateStorageAsync();
        }

        public async Task DeleteConnectionFromStorageAsync(ConnectionModel connection)
        {
            var list = await GetConnectionsListAsync();

            if (list.Connections!.Remove(connection))
                await UpdateConnectionsListAsync(list);
        }
    }
}