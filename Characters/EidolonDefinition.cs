namespace Project_Duskbreak.Characters;

public class EidolonDefinition
{
    public int Level { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public List<int> EffectIds { get; set; } = new();
}