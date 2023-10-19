using CommunityToolkit.Mvvm.ComponentModel;

using MongoDB_Android.Services.Storage.Connections;

using System.Collections.ObjectModel;

namespace MongoDB_Android.ViewModels
{
    public class ConnectionsViewModel : ConnectionModel
    {
        private ConnectionsStorage _storage;
        public ObservableCollection<ConnectionModel> Connections { get; private set; } = new();

        public ConnectionsViewModel(ConnectionsStorage connectionsStorage)
        {
            _storage = connectionsStorage;
        }

        public async Task GetConnectionAsync()
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
    }
}