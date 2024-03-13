namespace RandomValue.Player;

internal static class PlayersFactory
{
    public static IPlayer CreatePlayer() => new ConsolePlayer();
}