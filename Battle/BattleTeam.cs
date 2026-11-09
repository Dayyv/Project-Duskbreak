namespace Project_Duskbreak.Battle;

public class BattleTeam
{
    public string Name { get; set; }

    public List<IBattleUnit> Units { get; } = new();

    public BattleTeam(string name)
    {
        Name = name;
    }

    public IEnumerable<IBattleUnit> AliveUnits =>
        Units.Where(unit => unit.IsAlive);

    public bool IsDefeated =>
        AliveUnits.Any() == false;
}