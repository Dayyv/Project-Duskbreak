namespace Project_Duskbreak.Characters;

public static class CharacterDatabase
{
    private static readonly Dictionary<int, CharacterDefinition>
        _characters = new();

    public static void Register(
        CharacterDefinition character)
    {
        _characters[character.Id] = character;
    }

    public static CharacterDefinition Get(
        int id)
    {
        return _characters[id];
    }

    public static CharacterDefinition? GetByName(
        string name)
    {
        return _characters.Values
            .FirstOrDefault(
                x => x.Name.Equals(
                    name,
                    StringComparison.OrdinalIgnoreCase));
    }

    public static IReadOnlyCollection<CharacterDefinition>
        GetAll()
    {
        return _characters.Values;
    }

    public static void Clear()
    {
        _characters.Clear();
    }
}