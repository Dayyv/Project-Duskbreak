using System.Text.Json;
using System.Text.Json.Serialization;

namespace Project_Duskbreak.Skills;

public static class SkillLoader
{
    public static void LoadAll(
        string directory)
    {
        if (!Directory.Exists(directory))
        {
            throw new DirectoryNotFoundException(
                $"Directory not found: {directory}");
        }

        SkillDatabase.Clear();

        string[] files =
            Directory.GetFiles(
                directory,
                "*.json",
                SearchOption.TopDirectoryOnly);

        foreach (string file in files)
        {
            string json =
                File.ReadAllText(file);

            SkillDefinition? skill =
                JsonSerializer.Deserialize<SkillDefinition>(
    json,
    new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        Converters =
        {
            new JsonStringEnumConverter()
        }
    });


            if (skill == null)
                continue;

            SkillDatabase.Register(skill);

            Console.WriteLine(
                $"Loaded skill: {skill.Name}");
        }
    }
}