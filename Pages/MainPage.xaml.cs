namespace MongoDB_Android
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Locked;
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
            Shell.Current.FlyoutIsPresented = true;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///SavedConnections");
            Shell.Current.FlyoutIsPresented = false;
        }
    }
}