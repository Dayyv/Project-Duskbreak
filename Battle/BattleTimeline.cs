namespace Project_Duskbreak.Battle;

public class BattleTimeline
{
    public List<TimelineEntry> Entries { get; } = new();

    public void Sort()
    {
        Entries.Sort(
            (a, b) =>
                a.CurrentAV.CompareTo(
                    b.CurrentAV));
    }
}