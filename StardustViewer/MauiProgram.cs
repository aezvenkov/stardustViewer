using MetroLog.MicrosoftExtensions;
using Microsoft.Extensions.Logging;
using StardustViewer.ViewModel;

namespace StardustViewer
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Logging
            builder.Logging.AddTraceLogger(_ => { });

            // DI
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddTransient<DetailPage>();
            builder.Services.AddTransient<DetailViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}