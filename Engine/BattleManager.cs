using Project_Duskbreak.Battle;

namespace Project_Duskbreak.Engine;

public class BattleManager
{
    private readonly BattleState _battleState;

    public BattleManager(BattleState battleState)
    {
        _battleState = battleState;

        InitializeTimeline();
    }

    public BattleState BattleState => _battleState;

    private void InitializeTimeline()
    {
        _battleState.Timeline.Entries.Clear();

        foreach (var unit in _battleState.PlayerTeam.Units)
        {
            _battleState.Timeline.Entries.Add(
                new TimelineEntry(
                    unit,
                    CalculateBaseActionValue(unit.Speed)));
        }

        foreach (var unit in _battleState.EnemyTeam.Units)
        {
            _battleState.Timeline.Entries.Add(
                new TimelineEntry(
                    unit,
                    CalculateBaseActionValue(unit.Speed)));
        }

        _battleState.Timeline.Sort();
    }

    public TimelineEntry GetNextTurn()
    {
        _battleState.Timeline.Sort();

        TimelineEntry actor =
            _battleState.Timeline
                .Entries
                .First();

        double elapsedAV =
            actor.CurrentAV;

        foreach (var entry in _battleState.Timeline.Entries)
        {
            entry.CurrentAV -= elapsedAV;
        }

        _battleState.ActiveUnit =
            actor.Unit;

        _battleState.Log.LogTurnStart(
            actor.Unit.Name);

        return actor;
    }

    public void EndTurn(
    TimelineEntry actor)
    {
        _battleState.Log.LogTurnEnd(
            actor.Unit.Name);

        actor.CurrentAV =
            CalculateBaseActionValue(
                actor.Unit.Speed);

        _battleState.Timeline.Sort();
    }


    public void AdvanceForward(
        IBattleUnit target,
        double percentage)
    {
        TimelineEntry? entry =
            FindEntry(target);

        if (entry == null)
            return;

        entry.CurrentAV *=
            (1.0 - percentage);

        if (entry.CurrentAV < 0)
            entry.CurrentAV = 0;
    }

    public void Delay(
        IBattleUnit target,
        double percentage)
    {
        TimelineEntry? entry =
            FindEntry(target);

        if (entry == null)
            return;

        entry.CurrentAV *=
            (1.0 + percentage);
    }

    public void ModifyActionValue(
        IBattleUnit target,
        double amount)
    {
        TimelineEntry? entry =
            FindEntry(target);

        if (entry == null)
            return;

        entry.CurrentAV += amount;

        if (entry.CurrentAV < 0)
            entry.CurrentAV = 0;
    }

    public TimelineEntry? GetEntry(
        IBattleUnit unit)
    {
        return FindEntry(unit);
    }

    public IReadOnlyList<TimelineEntry> GetActionOrder()
    {
        _battleState.Timeline.Sort();

        return _battleState.Timeline.Entries
            .ToList();
    }

    private TimelineEntry? FindEntry(
        IBattleUnit unit)
    {
        return _battleState.Timeline
            .Entries
            .FirstOrDefault(x => x.Unit == unit);
    }

    private void RemoveDeadUnits()
    {
        _battleState.Timeline
            .Entries
            .RemoveAll(x => !x.Unit.IsAlive);
    }

    private static double CalculateBaseActionValue(
        double speed)
    {
        return 10000.0 / speed;
    }
}