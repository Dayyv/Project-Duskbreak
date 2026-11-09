namespace Project_Duskbreak.Skills;

public class SkillDefinition
{
    public int Id { get; set; }

    public string Name { get; set; }
        = string.Empty;

    public string Description { get; set; }
        = string.Empty;

    public SkillType SkillType
    { get; set; }

    public SkillTargetType TargetType
    { get; set; }

    public int SkillPointCost
    { get; set; }

    public int EnergyCost
    { get; set; }

    public int EnergyGain
    { get; set; }

    public List<SkillEffectDefinition>
        Effects
    { get; set; }
        = new();
}