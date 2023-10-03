namespace MongoDB_Android;

public partial class SavedConnectionsPage : ContentPage
{
	public SavedConnectionsPage()
	{
		InitializeComponent();
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.FlyoutIsPresented = true;
    }
}