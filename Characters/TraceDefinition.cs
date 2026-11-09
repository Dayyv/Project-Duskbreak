namespace Project_Duskbreak.Characters;

public class TraceDefinition
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public TraceType Type { get; set; }

    public string Description { get; set; } = string.Empty;

    public bool Unlocked { get; set; }

    public List<int> EffectIds { get; set; } = new();
}