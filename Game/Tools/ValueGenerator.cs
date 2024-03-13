namespace RandomValue.Tools;

internal class ValueGenerator : IValueGenerator
{
    private readonly Random _random = new();
    private readonly int _min;
    private readonly int _max;

    public ValueGenerator(int min, int max)
    {
        _min = min;
        _max = max;
    }

    public int GetValue()
    {
        return _random.Next(_min, _max);
    }
}