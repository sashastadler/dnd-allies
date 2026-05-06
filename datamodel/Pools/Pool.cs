namespace dnd_allies;

public enum PoolType
{
    None,
    Generic,
    HP,
    Counter
}

public abstract class Pool
{
    public PoolType Type { get; set; }

    public string Name { get; set; } = Constants.Empty;

    public int Max { get; set; }

    public int Min { get; set; }

    public int Current { get; set; }

    public abstract int ResetValue { get; }

    public void Modify(int amount) => Current = Math.Clamp(Current + amount, Min, Max);

    public void Reset() => Current = ResetValue;
}