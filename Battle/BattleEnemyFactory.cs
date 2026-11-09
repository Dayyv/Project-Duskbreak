using Project_Duskbreak.Enemies;

namespace Project_Duskbreak.Battle;

public static class BattleEnemyFactory
{
    public static BattleEnemy Create(
        EnemyDefinition definition)
    {
        CombatStats stats =
            new CombatStats();

        stats.BaseValues[
    StatType.MaxHp] =
    definition.Hp;
        stats.BaseValues[
    StatType.Attack] =
    definition.Atk;

        stats.BaseValues[
            StatType.Defense] =
            definition.Def;

        stats.BaseValues[
            StatType.Speed] =
            definition.Speed;

        return new BattleEnemy(
            definition,
            stats);
    }
}