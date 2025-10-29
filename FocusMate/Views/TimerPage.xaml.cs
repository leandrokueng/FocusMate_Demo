using FocusMate.ViewModels;
using Microsoft.Maui.Devices.Sensors;

namespace FocusMate.Views;

public partial class TimerPage : ContentPage
{
    public TimerPage()
    {
        InitializeComponent();

        
        MessagingCenter.Subscribe<SettingsPage>(this, "SettingsChanged", _ =>
        {
            (BindingContext as TimerViewModel)!.ReloadSettings();
            ToggleShake(); 
        });
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as TimerViewModel)!.ReloadSettings();
        ToggleShake();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        try
        {
            Accelerometer.ShakeDetected -= OnShake;
            if (Accelerometer.IsMonitoring) Accelerometer.Stop();
        }
        catch { }
    }

    private void ToggleShake()
    {
        var shakeOn = Preferences.Get(nameof(SettingsViewModel.ShakePause), false);
        try
        {
            Accelerometer.ShakeDetected -= OnShake;
            if (shakeOn)
            {
                Accelerometer.ShakeDetected += OnShake;
                if (!Accelerometer.IsMonitoring) Accelerometer.Start(SensorSpeed.Game);
            }
            else if (Accelerometer.IsMonitoring)
            {
                Accelerometer.Stop();
            }
        }
        catch { }
    }

    private async void OnShake(object? sender, EventArgs e)
        => await (BindingContext as TimerViewModel)!.PauseAsync();
}
