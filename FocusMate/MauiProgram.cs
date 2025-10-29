using FocusMate.Services;
using FocusMate.ViewModels;
using FocusMate.Views;

namespace FocusMate;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>();

        
        builder.Services.AddSingleton<StorageService>();

        
        builder.Services.AddSingleton<TimerViewModel>();
        builder.Services.AddSingleton<StatsViewModel>();
        builder.Services.AddSingleton<SettingsViewModel>();

        
        builder.Services.AddSingleton<TimerPage>();
        builder.Services.AddSingleton<StatsPage>();
        builder.Services.AddSingleton<SettingsPage>();

        return builder.Build();
    }
}
