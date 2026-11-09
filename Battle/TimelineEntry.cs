namespace Project_Duskbreak.Battle;

public class TimelineEntry
{
    public IBattleUnit Unit { get; set; }

    public double CurrentAV { get; set; }

    public TimelineEntry(
        IBattleUnit unit,
        double currentAV)
    {
        Unit = unit;
        CurrentAV = currentAV;
    }
}