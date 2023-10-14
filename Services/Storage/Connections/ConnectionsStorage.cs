using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System;

namespace MongoDB_Android.Services.Storage.Connections
{
    public class ConnectionsStorage
    {
        private readonly string _storage;
        private readonly string _cache;

        public ConnectionsStorage(string storageDirectory, string cacheDirectory)
        {
            _storage = storageDirectory;
            _cache = cacheDirectory;
            Debug.WriteLine("Storage directory: " + storageDirectory);
            Debug.WriteLine("Cache directory: " + cacheDirectory);
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

        public async Task AddNewConnectionToStorageAsync(string url)
        {
            var json = await GetConnectionsListAsync();
            json.Connections.Add(url);
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

        public async Task ClearConnectionsAsync()
        {
            File.Delete(_storage + "Connections.json");
            await CreateStorageAsync();
        }

        public async Task DeleteConnectionFromStorageAsync(string url)
        {
            var list = await GetConnectionsListAsync();

            if (list.Connections.Remove(url))
                await UpdateConnectionsListAsync(list);
        }
    }
}