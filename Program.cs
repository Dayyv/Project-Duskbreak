using Project_Duskbreak.Battle;
using Project_Duskbreak.Characters;
using Project_Duskbreak.Enemies;
using Project_Duskbreak.Engine;
using Project_Duskbreak.Skills;
using System.Text.Json.Serialization;


namespace Project_Duskbreak;

internal class Program
{
    static void Main(string[] args)
    {
        LoadDatabases();
        foreach (var skill in SkillDatabase.GetAll())
        {
            Console.WriteLine(
                $"{skill.Id} - {skill.Name}");
        }

        BattleTeam playerTeam =
            CreatePlayerTeam();

        BattleTeam enemyTeam =
            CreateEnemyTeam();

        BattleState battleState =
            new BattleState(
                playerTeam,
                enemyTeam);

        BattleManager battleManager =
            new BattleManager(
                battleState);

        RunTimelineSimulation(
            battleManager,
            20);
        PrintBattleLog(
    battleManager.BattleState);


        Console.ReadKey();
    }

    private static void LoadDatabases()
    {
        CharacterLoader.LoadAll(
            Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Data",
                "Characters"));

        EnemyLoader.LoadAll(
            Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Data",
                "Enemies"));
        SkillLoader.LoadAll(
    Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory,
        "Data",
        "Skills"));
    }


    private static BattleTeam CreatePlayerTeam()
    {
        BattleTeam team =
            new BattleTeam("Player");
        var jingliu =
    BattleAvatarFactory.Create(
        CharacterDatabase.Get(1212),
        80);

        var enemy =
            BattleEnemyFactory.Create(
                EnemyDatabase.Get(5013010));

        var skill =
            SkillDatabase.Get(
                jingliu.Definition.BasicAttackId);

        SkillExecutor.Execute(
            jingliu,
            enemy,
            skill);

        Console.WriteLine("=== AVAILABLE CHARACTERS ===");
        Console.WriteLine();

        foreach (var character in CharacterDatabase.GetAll())
        {
            Console.WriteLine(
                $"{character.Id} - {character.Name}");
        }

        Console.WriteLine();

        for (int i = 0; i < 4; i++)
        {
            Console.Write(
                $"Slot {i + 1} Character ID: ");

            int id =
                int.Parse(
                    Console.ReadLine() ?? "0");

            var definition =
                CharacterDatabase.Get(id);

            BattleAvatar avatar =
                BattleAvatarFactory.Create(
                    definition,
                    80);

            team.Units.Add(avatar);
        }

        return team;
    }

    private static BattleTeam CreateEnemyTeam()
    {
        BattleTeam team =
            new BattleTeam("Enemies");

        foreach (var enemyDefinition in
                 EnemyDatabase.GetAll().Take(5))
        {
            team.Units.Add(
                BattleEnemyFactory.Create(
                    enemyDefinition));
        }

        return team;
    }

    private static void RunTimelineSimulation(
        BattleManager battleManager,
        int turns)
    {
        for (int turn = 1; turn <= turns; turn++)
        {
            Console.Clear();

            Console.WriteLine(
                $"=== TURN {turn} ===");

            PrintCurrentTimeline(
    battleManager);

            PrintBattleLog(
                battleManager.BattleState);
            

            TimelineEntry actor =
                battleManager.GetNextTurn();

            Console.WriteLine();
            Console.WriteLine(
                $"ACTING UNIT: {actor.Unit.Name}");
            Console.WriteLine();

            battleManager.EndTurn(actor);

            Console.WriteLine(
                "Press any key...");

            Console.ReadKey();
        }
    }


    private static void PrintCurrentTimeline(
        BattleManager battleManager)
    {
        Console.WriteLine();
        Console.WriteLine("=== CURRENT TIMELINE ===");
        Console.WriteLine();

        int position = 1;

        foreach (var entry in battleManager.GetActionOrder())
        {
            double baseAV =
                10000.0 /
                entry.Unit.Speed;

            Console.WriteLine(
                $"{position++,2}. " +
                $"{entry.Unit.Name,-20} " +
                $"SPD: {entry.Unit.Speed,5:F0} " +
                $"Energy:{entry.Unit.CurrentEnergy,6:F0}/{entry.Unit.MaxEnergy,3:F0} " +
                $"CurrentAV: {entry.CurrentAV,8:F2} " +
                $"BaseAV: {baseAV,8:F2}");
        }

        Console.WriteLine();
    }
    private static void PrintBattleLog(
    BattleState state)
    {
        Console.WriteLine();
        Console.WriteLine("=== BATTLE LOG ===");
        Console.WriteLine();

        foreach (var entry in state.Log.Entries
                     .TakeLast(10))
        {
            Console.WriteLine(
                entry.Message);
        }

        Console.WriteLine();
    }
}