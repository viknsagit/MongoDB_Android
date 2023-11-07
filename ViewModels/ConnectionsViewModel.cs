using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using MongoDB_Android.Services.Storage.Connections;

using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MongoDB_Android.ViewModels
{
    public partial class ConnectionsViewModel : ConnectionModel
    {
        private ConnectionsStorage _storage;
        public ObservableCollection<ConnectionModel> Connections { get; private set; } = new();

        public ConnectionsViewModel(ConnectionsStorage connectionsStorage)
        {
            _storage = connectionsStorage;
        }

        public async Task GetConnectionsAsync()
        {
            try
            {
                var list = (await _storage.GetConnectionsListAsync()).Connections;
                if (Connections.Count != 0)
                    Connections.Clear();

                foreach (var connection in list!)
                    Connections.Add(connection);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Close");
            }
        }

        [RelayCommand]
        public async Task RemoveConnectionAsync(ConnectionModel connection)
        {
            await _storage.DeleteConnectionFromStorageAsync(connection);
            await GetConnectionsAsync();
        }

        [RelayCommand]
        public async Task EditConnectionAsync(ConnectionModel connection)
        {
            Debug.WriteLine("tapped edit");
        }

        [RelayCommand]
        public async Task ConnectAsync(ConnectionModel connectionUrl)
        {
            if (connectionUrl is null)
                await Task.CompletedTask;

            Debug.WriteLine($"Connecting {connectionUrl.Url}");




        }
    }
}