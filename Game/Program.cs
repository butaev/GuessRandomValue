using System.Text.Json;

namespace RandomValue;

internal class Program
{
    private static void Main()
    {
        string path = @"Config/config.json";
        var configData = File.ReadAllText(path);
        var config = JsonSerializer.Deserialize<Config.GameConfig>(configData);
        var game = new Game(config);
        game.Start();
        Console.WriteLine();
    }
}