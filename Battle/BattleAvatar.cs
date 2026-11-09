using Project_Duskbreak.Buffs;
using Project_Duskbreak.Characters;

namespace Project_Duskbreak.Battle;

public class BattleAvatar : IBattleUnit
{
    public CharacterDefinition Definition { get; }

    public CombatStats Stats { get; }

    public string Name =>
        Definition.Name;

    public int Level { get; }

    public double CurrentHp { get; set; }

    public double CurrentEnergy { get; set; }

    public double ActionValue { get; set; }

    public double MaxHp =>
    Stats.GetFinal(
        StatType.MaxHp);

    public double MaxEnergy =>
        Definition.MaxEnergy;

    public double Speed =>
        Stats.GetFinal(StatType.Speed);

    public bool IsAlive =>
        CurrentHp > 0;

    public List<StatusEffect> Buffs { get; } = new();

    public List<StatusEffect> Debuffs { get; } = new();

    public Dictionary<string, int> Stacks { get; } = new();

    public BattleAvatar(
        CharacterDefinition definition,
        CombatStats stats,
        int level)
    {
        Definition = definition;
        Stats = stats;

        Level = level;

        CurrentHp = MaxHp;
        CurrentEnergy = 0;

        ActionValue = 0;
    }
}