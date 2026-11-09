namespace Project_Duskbreak.Buffs;

public class StatusEffect
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Duration { get; set; }

    public double Value { get; set; }

    public StatusEffect(
        int id,
        string name,
        int duration,
        double value)
    {
        Id = id;
        Name = name;
        Duration = duration;
        Value = value;
    }
}