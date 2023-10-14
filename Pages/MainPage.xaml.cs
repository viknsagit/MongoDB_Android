using CommunityToolkit.Maui.Views;

using MongoDB_Android.Pages.PopupWindow;
using MongoDB_Android.Services.Storage.Connections;

namespace MongoDB_Android
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Locked;
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
            Shell.Current.FlyoutIsPresented = true;
            ConnectionsStorage storage = new(FileSystem.Current.AppDataDirectory, FileSystem.Current.CacheDirectory);
            await storage.CreateStorageAsync();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///SavedConnections");
            Shell.Current.FlyoutIsPresented = false;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var popup = new ConnectionSavePopup(false);
            this.ShowPopup(popup);
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            var popup = new ConnectionSavePopup(false);
            this.ShowPopup(popup);
        }
    }
}