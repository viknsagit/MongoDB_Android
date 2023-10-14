using CommunityToolkit.Maui.Views;

namespace MongoDB_Android.Pages.PopupWindow;

public partial class ConnectionSavePopup : Popup
{
    private readonly bool _connectToDatabase;

    public ConnectionSavePopup(bool connect)
    {
        InitializeComponent();
        _connectToDatabase = connect;
    }

    private async Task Close_Button(object sender, EventArgs e)
    {
        await CloseAsync();
    }

    private async Task Save_Button(object sender, EventArgs e)
    {
        await CloseAsync();
    }
}