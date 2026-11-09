public interface IBattleUnit
{
    string Name { get; }

    int Level { get; }

    double CurrentHp { get; set; }

    double MaxHp { get; }

    double CurrentEnergy { get; set; }

    double MaxEnergy { get; }

    double Speed { get; }

    double ActionValue { get; set; }

    bool IsAlive { get; }
}