using CommunityToolkit.Maui;

using Microsoft.Extensions.Logging;

using MongoDB_Android.Services.Storage.Connections;
using MongoDB_Android.ViewModels;

namespace MongoDB_Android
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Raleway-Regular.ttf", "Raleway");
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<ConnectionsStorage>();

            builder.Services.AddTransient<SavedConnectionsPage>();
            builder.Services.AddTransient<ConnectionsViewModel>();

            //Убираю подчеркивание в Entry глобально.
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#endif
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}