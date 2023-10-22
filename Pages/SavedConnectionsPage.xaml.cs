using MongoDB_Android.ViewModels;

namespace MongoDB_Android;

public partial class SavedConnectionsPage : ContentPage
{
    private ConnectionsViewModel _connectionViewModel;

    public SavedConnectionsPage(ConnectionsViewModel connectionsViewModel)
    {
        InitializeComponent();
        BindingContext = connectionsViewModel;
        _connectionViewModel = connectionsViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _connectionViewModel.GetConnectionsAsync();
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        //bug in MAUI
        Shell.Current.FlyoutBehavior = FlyoutBehavior.Locked;
        Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
        Shell.Current.FlyoutIsPresented = true;
    }
}