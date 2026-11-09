namespace Project_Duskbreak.Effects;

public class EffectDefinition
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public EffectType EffectType { get; set; }

    public ModifierTarget Target { get; set; }

    public TriggerType Trigger { get; set; }

    public StatType? Stat { get; set; }

    public ModifierType? ModifierType { get; set; }

    public double Value { get; set; }

    public int Duration { get; set; }

    public string StackName { get; set; } = string.Empty;

    public int StackAmount { get; set; }
}
