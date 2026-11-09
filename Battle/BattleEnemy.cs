using Project_Duskbreak.Buffs;
using Project_Duskbreak.Enemies;

namespace Project_Duskbreak.Battle;

public class BattleEnemy : IBattleUnit
{
    public EnemyDefinition Definition { get; }

    public CombatStats Stats { get; }

    public string Name =>
        Definition.Name;

    public int Level =>
        Definition.Level;

    public double CurrentHp { get; set; }

    public double CurrentEnergy { get; set; }

    public double ActionValue { get; set; }

    public double MaxHp =>
        Stats.GetBase(StatType.MaxHp);

    public double MaxEnergy =>
        0;

    public double Speed =>
        Stats.GetBase(StatType.Speed);

    public bool IsAlive =>
        CurrentHp > 0;

    public int MaxToughness =>
        Definition.Toughness;

    public int CurrentToughness { get; set; }

    public bool IsBroken =>
        CurrentToughness <= 0;

    public List<StatusEffect> Buffs { get; } =
        new();

    public List<StatusEffect> Debuffs { get; } =
        new();

    public BattleEnemy(
        EnemyDefinition definition,
        CombatStats stats)
    {
        Definition = definition;
        Stats = stats;

        CurrentHp = MaxHp;

        CurrentEnergy = 0;

        CurrentToughness =
            definition.Toughness;
    }
}