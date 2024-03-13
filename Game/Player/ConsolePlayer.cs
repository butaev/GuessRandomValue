namespace RandomValue.Player;

internal class ConsolePlayer : IPlayer
{
    public int TryGuess()
    {
        Console.WriteLine("Write guess number:");
        var number = 0;
        try
        {
            number = int.Parse(Console.ReadLine().Split().FirstOrDefault());
        }
        catch (Exception e)
        {
            Console.WriteLine("Wasted");
        }

        return number;
    }
}