namespace dnd_allies;

public class GenericPool : Pool
{
    // Initializes a generic pool with a start value of 0.
    public GenericPool()
    {
        Min = Constants.DefaultMinHp;
        Max = Constants.DefaultPoolSize;
        Current = Min;
    }
    public override int ResetValue => Min;
}