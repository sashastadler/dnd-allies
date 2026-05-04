namespace dnd_allies;

public class GenericPool : Pool
{
    // Initializes a generic pool with a start value of 0.
    public GenericPool()
    {
        Min = Constants.DefaultMinHp;
        Max = Constants.DefaultPoolSize;
        Current = Min;
        Type = PoolType.Generic;
    }

    public string Name { get; set; } = Constants.Empty;
    public override int ResetValue => Min;
    public new void Modify(int amount) => Current = Math.Clamp(Current + amount, Min, Max);
}