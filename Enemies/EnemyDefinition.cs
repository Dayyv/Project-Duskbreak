namespace Project_Duskbreak.Enemies;

public class EnemyDefinition
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Level { get; set; }

    public double Hp { get; set; }

    public double Atk { get; set; }

    public double Def { get; set; }

    public double Speed { get; set; }

    public int Toughness { get; set; }

    public List<string> Weaknesses { get; set; } =
        new();

    public Dictionary<string, double> Resistances { get; set; } =
        new();
}