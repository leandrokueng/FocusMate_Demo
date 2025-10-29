using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FocusMate.Models;
using FocusMate.Services;

namespace FocusMate.ViewModels;

public partial class TimerViewModel : ObservableObject
{
    private readonly StorageService _storage;

    private CancellationTokenSource? _cts;
    private DateTime _start;
    private bool _running;

    [ObservableProperty] private string _timeText = "25:00";
    [ObservableProperty] private int _focusMinutes = 25;

    
    public TimerViewModel() : this(new StorageService()) { }

    
    public TimerViewModel(StorageService storage)
    {
        _storage = storage;
        ReloadSettings();
    }

    
    public void ReloadSettings()
    {
        FocusMinutes = Preferences.Get(nameof(FocusMinutes), 25);
        
        TimeText = $"{FocusMinutes:00}:00";
    }

    [RelayCommand]
    public async Task StartAsync()
    {
        if (_running) return;
        _running = true;
        _cts = new();
        _start = DateTime.Now;

        var target = TimeSpan.FromMinutes(FocusMinutes);
        TryVibrate(40);

        try
        {
            var sw = Stopwatch.StartNew();
            while (sw.Elapsed < target && !_cts.IsCancellationRequested)
            {
                var remain = target - sw.Elapsed;
                if (remain < TimeSpan.Zero) remain = TimeSpan.Zero;
                TimeText = $"{(int)remain.TotalMinutes:00}:{remain.Seconds:00}";
                await Task.Delay(200, _cts.Token);
            }

            if (!_cts.IsCancellationRequested)
            {
                TryVibrate(120);
                await _storage.AddSessionAsync(new FocusSession
                {
                    StartedAt = _start,
                    DurationSeconds = (int)target.TotalSeconds,
                    Completed = true
                });
            }
        }
        catch (TaskCanceledException) { }
        finally
        {
            _running = false;
            _cts?.Dispose();
            _cts = null;
        }
    }

    [RelayCommand]
    public async Task PauseAsync()
    {
        if (!_running) return;

        _cts?.Cancel();
        TryVibrate(60);

        var elapsedSeconds = FocusMinutes * 60 - ParseSeconds(TimeText);
        if (elapsedSeconds < 0) elapsedSeconds = 0;

        await _storage.AddSessionAsync(new FocusSession
        {
            StartedAt = _start,
            DurationSeconds = elapsedSeconds,
            Completed = false
        });

        _running = false;
    }

    private static int ParseSeconds(string mmss)
    {
        var p = mmss.Split(':');
        if (p.Length != 2) return 0;
        return int.Parse(p[0]) * 60 + int.Parse(p[1]);
    }

    private static void TryVibrate(int ms)
    {
        try { Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(ms)); } catch { }
    }
}
