using SQLite;

namespace FocusMate.Models;

public class FocusSession
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
    public DateTime StartedAt { get; set; }
    public int DurationSeconds { get; set; }
    public bool Completed { get; set; }
}
