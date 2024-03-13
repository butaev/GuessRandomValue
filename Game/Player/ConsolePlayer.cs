namespace RandomValue.Player;

internal class ConsolePlayer : IPlayer
{
    public int? TryGuess()
    {
        Console.WriteLine("Write guess number:");

        var input = Console.ReadLine();
        if (int.TryParse(input, out var value))
        {
            return value;
        }

        return null;
    }
}