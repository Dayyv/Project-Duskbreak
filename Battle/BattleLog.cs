namespace Project_Duskbreak.Battle;

public class BattleLog
{
    private readonly List<BattleLogEntry>
        _entries = new();

    public IReadOnlyList<BattleLogEntry>
        Entries => _entries;

    public void Add(string message)
    {
        _entries.Add(
            new BattleLogEntry(message));
    }

    public void Clear()
    {
        _entries.Clear();
    }

    // ===== Turn =====

    public void LogTurnStart(
        string unitName)
    {
        Add(
            $"[TURN START] {unitName}");
    }

    public void LogTurnEnd(
        string unitName)
    {
        Add(
            $"[TURN END] {unitName}");
    }

    // ===== Skills =====

    public void LogSkill(
        string unitName,
        string skillName)
    {
        Add(
            $"{unitName} used {skillName}.");
    }

    // ===== Damage =====

    public void LogDamage(
        string attackerName,
        string targetName,
        double damage)
    {
        Add(
            $"{attackerName} dealt {damage:F0} damage to {targetName}.");
    }

    // ===== Healing =====

    public void LogHeal(
        string healerName,
        string targetName,
        double heal)
    {
        Add(
            $"{healerName} healed {targetName} for {heal:F0}.");
    }

    // ===== Buffs =====

    public void LogBuff(
        string sourceName,
        string targetName,
        string buffName)
    {
        Add(
            $"{sourceName} applied {buffName} to {targetName}.");
    }

    public void LogDebuff(
        string sourceName,
        string targetName,
        string debuffName)
    {
        Add(
            $"{sourceName} applied {debuffName} to {targetName}.");
    }

    // ===== Death =====

    public void LogDeath(
        string unitName)
    {
        Add(
            $"{unitName} was defeated.");
    }
}