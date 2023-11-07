using MongoDB_Android.Pages;

namespace MongoDB_Android
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SavedConnectionsPage), typeof(SavedConnectionsPage));
            Routing.RegisterRoute(nameof(ServerPage), typeof(ServerPage));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///MainPage");
            Shell.Current.FlyoutIsPresented = false;
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///SavedConnections");
            Shell.Current.FlyoutIsPresented = false;
        }
    }
}