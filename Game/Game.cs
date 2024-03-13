using RandomValue.Tools;
using RandomValue.Config;
using RandomValue.Player;

namespace RandomValue;

internal class Game
{
    private readonly IGameConfig _config;
    private readonly List<IPlayer> _players;
    private readonly Dictionary<IPlayer, (bool guessed, int trialNumber)> _stats;

    private readonly int _value;

    public Game(IGameConfig config, IValueGenerator valueGenerator, IPlayersFactory factory)
    {
        _config = config;
        _players = new List<IPlayer>();
        for (var i = 0; i < _config.PlayersCount; i++)
        {
            _players.Add(factory.CreatePlayer());
        }

        _stats = _players.ToDictionary(p => p, _ => (false, 0));
        _value = valueGenerator.GetValue();
    }

    public void Start()
    {
        Console.WriteLine("START");
        Console.WriteLine($"Try to guess the number from {_config.Min} to {_config.Max} in {_config.TrialsCount} trials");
        while (true)
        {
            if (IsGameOver())
            {
                return;
            }

            for (var i = 0; i < _players.Count; i++)
            {
                HandlePlayer(i);
            }

            Console.WriteLine("-----------------------------");
        }
    }

    private bool IsGameOver()
    {
        if (_stats.Count == 0)
        {
            Console.WriteLine("WIN");
            return true;
        }

        if (_stats.All(s => s.Value.trialNumber >= _config.TrialsCount))
        {
            for (var i = 0; i < _players.Count; i++)
            {
                var player = _players[i];
                if (_stats.ContainsKey(player))
                {
                    Console.WriteLine($"Player {i + 1} lost.");
                }
            }

            return true;
        }

        return false;
    }

    private void HandlePlayer(int i)
    {
        var player = _players[i];
        if (!_stats.ContainsKey(player))
        {
            return;
        }

        var stat = _stats[player];
        if (!stat.guessed)
        {
            stat.trialNumber++;
            Console.WriteLine();
            Console.WriteLine($"Player {i + 1}, trial number {stat.trialNumber}.");
            if (RightGuess(player.TryGuess()))
            {
                stat.guessed = true;
                Console.WriteLine($"Player {i + 1} wins.");
            }
        }

        _stats[player] = stat;
        if (stat.guessed)
        {
            _stats.Remove(player);
        }
    }

    private bool RightGuess(int? value)
    {
        if (value == null)
        {
            Console.WriteLine("Invalid value");
            return false;
        }

        if (value < _value)
        {
            Console.WriteLine("Less");
            return false;
        }

        if (value > _value)
        {
            Console.WriteLine("More");
            return false;
        }

        Console.WriteLine("Right");
        return true;
    }
}