using System.Text.Json;
using System.Text.Json.Serialization;

namespace Project_Duskbreak.Characters;

public static class CharacterLoader
{
    public static void LoadAll(string directory)
    {
        if (!Directory.Exists(directory))
        {
            throw new DirectoryNotFoundException(
                $"Directory not found: {directory}");
        }

        CharacterDatabase.Clear();

        string[] files =
            Directory.GetFiles(
                directory,
                "*.json",
                SearchOption.TopDirectoryOnly);

        foreach (string file in files)
        {
            string json =
                File.ReadAllText(file);

            CharacterDefinition? character =
                JsonSerializer.Deserialize<CharacterDefinition>(
    json,
    new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        Converters =
        {
            new JsonStringEnumConverter()
        }
    });


            if (character == null)
            {
                Console.WriteLine(
                    $"Failed to load: {file}");

                continue;
            }

            CharacterDatabase.Register(character);

            Console.WriteLine(
                $"Loaded character: {character.Name}");
        }
    }
}