using CommunityToolkit.Mvvm.ComponentModel;
using FocusMate.Services;

namespace FocusMate.ViewModels;

public partial class StatsViewModel : ObservableObject
{
    private readonly StorageService _storage;

    [ObservableProperty] private string _todayText = "Heute: 0 min";

    public StatsViewModel() : this(new StorageService()) { }
    public StatsViewModel(StorageService storage) => _storage = storage;

    public async Task LoadAsync()
    {
        var list = await _storage.GetRecentAsync(7);
        var totalToday = list
            .Where(x => x.StartedAt.Date == DateTime.Today)
            .Sum(x => x.DurationSeconds / 60);
        TodayText = $"Heute: {totalToday} min konzentriert";
    }

    public async Task ClearAsync() => await _storage.ClearAsync();
}
