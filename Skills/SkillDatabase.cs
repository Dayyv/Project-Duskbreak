namespace Project_Duskbreak.Skills;

public static class SkillDatabase
{
    private static readonly Dictionary<int, SkillDefinition>
        _skills = new();

    public static void Register(
        SkillDefinition skill)
    {
        _skills[skill.Id] = skill;
    }

    public static SkillDefinition Get(
        int id)
    {
        return _skills[id];
    }

    public static IReadOnlyCollection<SkillDefinition>
        GetAll()
    {
        return _skills.Values;
    }

    public static void Clear()
    {
        _skills.Clear();
    }
}