using Project_Duskbreak.Battle;

namespace Project_Duskbreak.Skills;

public static class SkillExecutor
{
    public static void Execute(
    BattleAvatar attacker,
    BattleEnemy target,
    SkillDefinition skill)
    {
        foreach (var effect in skill.Effects)
        {
            switch (effect.Type)
            {
                case SkillEffectType.Damage:
                    ExecuteDamage(
                        attacker,
                        target,
                        effect);
                    break;
            }
        }

        attacker.CurrentEnergy += skill.EnergyGain;

        if (attacker.CurrentEnergy >
            attacker.MaxEnergy)
        {
            attacker.CurrentEnergy =
                attacker.MaxEnergy;
        }

        BattleLog.Write(
            $"{attacker.Name} gained {skill.EnergyGain} Energy");
    }

    private static void ExecuteDamage(
        BattleAvatar attacker,
        BattleEnemy target,
        SkillEffectDefinition effect)
    {
        double scalingValue =
            GetScalingValue(
                attacker,
                effect.ScalingStat);

        double damage =
            scalingValue *
            effect.Multiplier;

        target.CurrentHp -= damage;

        if (target.CurrentHp < 0)
        {
            target.CurrentHp = 0;
        }

        BattleLog.Write(
    $"{attacker.Name} dealt {damage:F0} damage to {target.Name}");
        
    }

    private static double GetScalingValue(
        BattleAvatar attacker,
        ScalingStat stat)
    {
        return stat switch
        {
            ScalingStat.Atk =>
                attacker.Stats.GetFinal(
                    StatType.Attack),

            ScalingStat.Def =>
                attacker.Stats.GetFinal(
                    StatType.Defense),

            ScalingStat.Hp =>
                attacker.Stats.GetFinal(
                    StatType.MaxHp),

            ScalingStat.Speed =>
                attacker.Stats.GetFinal(
                    StatType.Speed),

            _ => 0
        };
    }
}