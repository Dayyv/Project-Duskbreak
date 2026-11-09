namespace Project_Duskbreak.Skills;

public class SkillEffectDefinition
{
    public SkillEffectType Type
    { get; set; }

    public ScalingStat ScalingStat
    { get; set; }

    public double Multiplier
    { get; set; }

    public string Element
    { get; set; } = string.Empty;

    public int Value
    { get; set; }
}
