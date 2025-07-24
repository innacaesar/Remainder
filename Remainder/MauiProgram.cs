using Microsoft.Extensions.Logging;

namespace Remainder
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
                    fonts.AddFont("MaterialSymbolsOutlined.ttf", "MaterialSymbols");
                });
            //Dependency Injection
            builder.Services.AddSingleton<Services.ITaskRepository, Services.TodoDatabase>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<ViewModels.MainViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
