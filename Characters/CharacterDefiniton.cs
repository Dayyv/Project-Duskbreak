using Project_Duskbreak.Skills;

namespace Project_Duskbreak.Characters;

public class CharacterDefinition
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Path { get; set; } = string.Empty;

    public string Element { get; set; } = string.Empty;

    public int MaxEnergy { get; set; }

    public double BaseHp { get; set; }

    public double BaseAtk { get; set; }

    public double BaseDef { get; set; }

    public double BaseSpeed { get; set; }

    public int BasicAttackId { get; set; }

    public int SkillId { get; set; }

    public int UltimateId { get; set; }

    public int TalentId { get; set; }

    public List<MinorTraceDefinition> MinorTraces { get; set; } = new();

    public List<TraceDefinition> MajorTraces { get; set; } = new();
    public List<EidolonDefinition> Eidolons { get; set; } = new();
}