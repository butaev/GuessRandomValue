namespace RandomValue.Config;

internal interface IGameConfig
{
    public int PlayersCount { get; }
    public int TrialsCount { get; }
    public int Min { get; }
    public int Max { get; }
}