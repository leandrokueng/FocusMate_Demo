using CommunityToolkit.Mvvm.ComponentModel;

namespace FocusMate.ViewModels;

public partial class SettingsViewModel : ObservableObject
{
    [ObservableProperty] private bool _autoDarkMode = true;
    [ObservableProperty] private bool _shakePause = false;
    [ObservableProperty] private int _focusMinutes = 25;

    public SettingsViewModel()
    {
        AutoDarkMode = Preferences.Get(nameof(AutoDarkMode), true);
        ShakePause = Preferences.Get(nameof(ShakePause), false);
        FocusMinutes = Preferences.Get(nameof(FocusMinutes), 25);
    }

    public void Save()
    {
        Preferences.Set(nameof(AutoDarkMode), AutoDarkMode);
        Preferences.Set(nameof(ShakePause), ShakePause);
        Preferences.Set(nameof(FocusMinutes), FocusMinutes);
    }
}
