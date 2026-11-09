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
        if (!_skills.TryGetValue(
            id,
            out SkillDefinition? skill))
        {
            throw new KeyNotFoundException(
                $"Skill with ID {id} not found.");
        }

        return skill;
    }

    public static bool TryGet(
        int id,
        out SkillDefinition? skill)
    {
        return _skills.TryGetValue(
            id,
            out skill);
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

    public static bool Exists(
        int id)
    {
        return _skills.ContainsKey(id);
    }
}