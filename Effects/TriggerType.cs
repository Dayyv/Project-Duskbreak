namespace Project_Duskbreak.Effects;

public enum TriggerType
{
    None,

    BattleStart,

    TurnStart,
    TurnEnd,

    BeforeAttack,
    AfterAttack,

    BeforeSkill,
    AfterSkill,

    OnHit,

    OnKill,

    OnBreak,

    OnUltimate,

    OnFollowUp,

    OnDot
}