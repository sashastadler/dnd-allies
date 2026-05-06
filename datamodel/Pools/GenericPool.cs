namespace dnd_allies;

public class GenericPool : Pool
{
    // Initializes a generic pool with a start value of 0 that resets to 0.
    public GenericPool()
    {
        Min = Constants.DefaultMinHp;
        Max = Constants.DefaultPoolSize;
        Current = Min;
        Type = PoolType.Generic;
    }
    public override int ResetValue => Min;
}

public class CounterPool : Pool
{
    // A pool that can only count up by 1. Does not reset.
    public CounterPool()
    {
        Min = 0;
        Type = PoolType.Counter;
        Max = Constants.DefaultPoolSize;
    }

    public override int ResetValue => Current;
    public new void Modify(int amount) => Current = Math.Clamp(Current + 1, Min, Max);
}