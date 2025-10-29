using FocusMate.ViewModels;

namespace FocusMate.Views;

public partial class StatsPage : ContentPage
{
    public StatsPage()
    {
        InitializeComponent();
    }

    private async void ContentPage_Appearing(object sender, EventArgs e)
        => await (BindingContext as StatsViewModel)!.LoadAsync();

    private async void OnClearClicked(object sender, EventArgs e)
    {
        var vm = (BindingContext as StatsViewModel)!;
        await vm.ClearAsync();
        await vm.LoadAsync(); // <- UI aktualisieren
        await DisplayAlert("Erledigt", "Statistik wurde gelöscht.", "OK");
    }
}
