namespace RandomValue.Config;

internal class GameConfig : IGameConfig
{
    public int PlayersCount { get; }
    public int TrialsCount { get; }
    public int Min { get; }
    public int Max { get; }

    public GameConfig(int playersCount, int trialsCount, int min, int max)
    {
        PlayersCount = playersCount;
        TrialsCount = trialsCount;
        Min = min;
        Max = max;
    }
}