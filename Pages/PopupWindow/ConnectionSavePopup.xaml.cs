using CommunityToolkit.Maui.Views;

using MongoDB_Android.Services.Storage.Connections;

namespace MongoDB_Android.Pages.PopupWindow;

public partial class ConnectionSavePopup : Popup
{
    private readonly bool _connectToDatabase;

    public ConnectionSavePopup(bool connect)
    {
        InitializeComponent();
        _connectToDatabase = connect;
    }

    private async void Close_Button(object sender, EventArgs e)
    {
        await CloseAsync();
    }

    private async void Save_Button(object sender, EventArgs e)
    {
        await CloseAsync(Entry.Text);
    }
}