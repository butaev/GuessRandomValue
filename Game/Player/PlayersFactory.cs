namespace RandomValue.Player;

internal class PlayersFactory : IPlayersFactory
{
    public IPlayer CreatePlayer() => new ConsolePlayer();
}