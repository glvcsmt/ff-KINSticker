using Microsoft.Extensions.Logging;
using RJVTD2_MP_2025261.ViewModels;
using RJVTD2_MP_2025261.Views;
using RJVTD2_MP_2025261.Data;

namespace RJVTD2_MP_2025261;

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
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<HomePageViewModel>();
        builder.Services.AddSingleton<IStickerDatabase, SQLiteStickerDatabase>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}