namespace Project_Duskbreak.Battle;

public class CombatStats
{
    public Dictionary<StatType, double> BaseValues
    { get; } = new();

    public Dictionary<StatType, double> FlatBonuses
    { get; } = new();

    public Dictionary<StatType, double> PercentBonuses
    { get; } = new();
    public double GetBase(
    StatType stat)
    {
        return BaseValues.TryGetValue(
            stat,
            out double value)
            ? value
            : 0;
    }
    public double GetFlat(
    StatType stat)
    {
        return FlatBonuses.TryGetValue(
            stat,
            out double value)
            ? value
            : 0;
    }
    public double GetPercent(
    StatType stat)
    {
        return PercentBonuses.TryGetValue(
            stat,
            out double value)
            ? value
            : 0;
    }
    public void AddFlat(
    StatType stat,
    double value)
    {
        FlatBonuses[stat] =
            GetFlat(stat) + value;
    }
    public void AddPercent(
    StatType stat,
    double value)
    {
        PercentBonuses[stat] =
            GetPercent(stat) + value;
    }
    public double GetFinal(
    StatType stat)
    {
        double baseValue =
            GetBase(stat);

        double flatValue =
            GetFlat(stat);

        double percentValue =
            GetPercent(stat);

        return
            (baseValue + flatValue)
            *
            (1.0 + percentValue);
    }
    public void SetBase(
    StatType stat,
    double value)
    {
        BaseValues[stat] = value;
    }
    public void SetFlat(
    StatType stat,
    double value)
    {
        FlatBonuses[stat] = value;
    }

    public void SetPercent(
        StatType stat,
        double value)
    {
        PercentBonuses[stat] = value;
    }
}
