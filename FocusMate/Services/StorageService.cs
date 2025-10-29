using SQLite;
using FocusMate.Models;

namespace FocusMate.Services;

public class StorageService
{
    private SQLiteAsyncConnection? _db;
    private const string DbName = "focusmate.db3";

    public async Task InitAsync()
    {
        if (_db != null) return;
        var path = Path.Combine(FileSystem.AppDataDirectory, DbName);
        _db = new SQLiteAsyncConnection(path);
        await _db.CreateTableAsync<FocusSession>();
    }

    public async Task AddSessionAsync(FocusSession s)
    {
        await InitAsync();
        await _db!.InsertAsync(s);
    }

    public async Task<List<FocusSession>> GetRecentAsync(int days = 7)
    {
        await InitAsync();
        var since = DateTime.Now.Date.AddDays(-days);
        return await _db!.Table<FocusSession>()
            .Where(x => x.StartedAt >= since)
            .OrderByDescending(x => x.StartedAt)
            .ToListAsync();
    }

    public async Task ClearAsync()
    {
        await InitAsync();
        await _db!.DeleteAllAsync<FocusSession>();
    }
}
