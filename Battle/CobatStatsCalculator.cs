using Project_Duskbreak.Characters;

namespace Project_Duskbreak.Battle;

public static class CombatStatsCalculator
{
    public static CombatStats Build(
        CharacterDefinition character,
        int level)
    {
        CombatStats stats =
            new CombatStats();

        ApplyBaseStats(
            stats,
            character);

        ApplyDefaultStats(
            stats);


        return stats;
    }

    private static void ApplyBaseStats(
        CombatStats stats,
        CharacterDefinition character)
    {
        stats.BaseValues[
            StatType.MaxHp]
            = character.BaseHp;

        stats.BaseValues[
    StatType.Attack]
    = character.BaseAtk;


        stats.BaseValues[
            StatType.Defense]
            = character.BaseDef;

        stats.BaseValues[
            StatType.Speed]
            = character.BaseSpeed;
    }

    private static void ApplyDefaultStats(
        CombatStats stats)
    {
        stats.BaseValues[
            StatType.CritRate]
            = 0.05;

        stats.BaseValues[
            StatType.CritDamage]
            = 0.50;
        stats.BaseValues[
            StatType.BreakEffect]
            = 0.00;

        stats.BaseValues[
            StatType.EffectHitRate]
            = 0.00;
        stats.BaseValues[
            StatType.EffectRes]
            = 0.00;

        stats.BaseValues[
            StatType.EnergyRegenerationRate]
            = 1.00;
        stats.BaseValues[
            StatType.AllDamage]
            = 0.00;

        stats.BaseValues[
            StatType.DefenseIgnore]
            = 0.00;
        stats.BaseValues[
            StatType.ResPen]
            = 0.00;
    }

}