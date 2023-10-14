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

    private void Button_Clicked(object sender, EventArgs e)
    {
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
    }
}