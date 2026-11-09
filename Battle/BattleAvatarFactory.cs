using Project_Duskbreak.Characters;

namespace Project_Duskbreak.Battle;

public static class BattleAvatarFactory
{
    public static BattleAvatar Create(
        CharacterDefinition definition,
        int level)
    {
        CombatStats stats =
            CombatStatsCalculator.Build(
                definition,
                level);

        return new BattleAvatar(
            definition,
            stats,
            level);
    }
}