using System.Text.Json;
using RandomValue.Player;
using RandomValue.Tools;

namespace RandomValue;

internal class Program
{
    private static void Main()
    {
        const string path = @"Config/config.json";
        var configData = File.ReadAllText(path);
        try
        {
            var config = JsonSerializer.Deserialize<Config.GameConfig>(configData);
            if (config == null)
                throw new NullReferenceException("Invalid config initialization");
            var valueGenerator = new ValueGenerator(config.Min, config.Max);
            var playersFactory = new PlayersFactory();
            var game = new Game(config, valueGenerator, playersFactory);
            game.Start();
            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}