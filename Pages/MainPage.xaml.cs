using CommunityToolkit.Maui.Views;

using MongoDB_Android.Pages.PopupWindow;
using MongoDB_Android.Services.Storage.Connections;

using System.Diagnostics;

namespace MongoDB_Android
{
    public partial class MainPage : ContentPage
    {
        private ConnectionsStorage _connectionStorage;

        public MainPage(ConnectionsStorage connectionsStorage)
        {
            InitializeComponent();
            _connectionStorage = connectionsStorage;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _connectionStorage.CreateStorageAsync();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            //bug in MAUI
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Locked;
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
            Shell.Current.FlyoutIsPresented = true;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///SavedConnections");
            Shell.Current.FlyoutIsPresented = false;
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await DisplayPopup();
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await DisplayPopup();
        }

        private async Task DisplayPopup()
        {
            var popup = new ConnectionSavePopup(true);
            var result = await this.ShowPopupAsync(popup);
            if (result is string name)
            {
                await _connectionStorage.AddNewConnectionToStorageAsync(new Connection() { Name = name, UnixTimeAdd = DateTimeOffset.Now.ToUnixTimeSeconds().ToString(), Url = UrlEntry.Text });
            }
        }
    }
}