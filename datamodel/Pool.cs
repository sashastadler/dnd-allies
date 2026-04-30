namespace dnd_allies;

public abstract class Pool
{
    public int Max { get; set; }

    public int Min { get; set; }

    public int Current { get; set; }

    public abstract int ResetValue { get; }

    public void Modify(int amount) => Current += amount;

    public void Reset() => Current = ResetValue;
}