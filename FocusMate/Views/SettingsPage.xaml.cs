using FocusMate.ViewModels;

namespace FocusMate.Views;

public partial class SettingsPage : ContentPage
{
    public SettingsPage() => InitializeComponent();

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        var vm = (BindingContext as SettingsViewModel)!;
        vm.Save();

        
        Application.Current!.UserAppTheme = vm.AutoDarkMode ? AppTheme.Dark : AppTheme.Light;

        
        MessagingCenter.Send(this, "SettingsChanged");

        await DisplayAlert("Gespeichert", "Einstellungen übernommen.", "OK");
    }
}
