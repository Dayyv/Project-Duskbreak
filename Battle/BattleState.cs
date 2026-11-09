namespace Project_Duskbreak.Battle;

public class BattleState
{
    public BattleTeam PlayerTeam { get; set; }

    public BattleTeam EnemyTeam { get; set; }

    public BattleTimeline Timeline { get; set; }

    public int SkillPoints { get; set; }

    public int MaxSkillPoints { get; set; }

    public int CurrentCycle { get; set; }

    public IBattleUnit? ActiveUnit { get; set; }
    public BattleLog Log { get; }
    = new();    
    public BattleState(
        BattleTeam playerTeam,
        BattleTeam enemyTeam)
    {
        PlayerTeam = playerTeam;
        EnemyTeam = enemyTeam;

        Timeline = new BattleTimeline();

        SkillPoints = 3;
        MaxSkillPoints = 5;

        CurrentCycle = 0;
    }
}