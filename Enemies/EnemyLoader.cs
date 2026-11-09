using System.Text.Json;

namespace Project_Duskbreak.Enemies;

public static class EnemyLoader
{
    public static void LoadAll(
        string directory)
    {
        if (!Directory.Exists(directory))
        {
            throw new DirectoryNotFoundException(
                $"Directory not found: {directory}");
        }

        EnemyDatabase.Clear();

        string[] files =
            Directory.GetFiles(
                directory,
                "*.json",
                SearchOption.TopDirectoryOnly);

        foreach (string file in files)
        {
            string json =
                File.ReadAllText(file);

            EnemyDefinition? enemy =
                JsonSerializer.Deserialize<EnemyDefinition>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            if (enemy == null)
                continue;

            EnemyDatabase.Register(enemy);

            Console.WriteLine(
                $"Loaded enemy: {enemy.Name}");
        }
    }
}