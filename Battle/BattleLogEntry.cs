namespace Project_Duskbreak.Battle;

public class BattleLogEntry
{
    public DateTime Timestamp { get; }

    public string Message { get; }

    public BattleLogEntry(
        string message)
    {
        Timestamp = DateTime.Now;

        Message = message;
    }
}