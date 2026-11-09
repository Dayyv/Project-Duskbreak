namespace Project_Duskbreak.Enemies;

public static class EnemyDatabase
{
    private static readonly Dictionary<int, EnemyDefinition>
        _enemies = new();

    public static void Register(
        EnemyDefinition enemy)
    {
        _enemies[enemy.Id] = enemy;
    }

    public static EnemyDefinition Get(
        int id)
    {
        return _enemies[id];
    }

    public static IReadOnlyCollection<EnemyDefinition>
        GetAll()
    {
        return _enemies.Values;
    }

    public static void Clear()
    {
        _enemies.Clear();
    }
}