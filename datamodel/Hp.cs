using System.Security.RightsManagement;

namespace dnd_allies;

public class Hp : Pool
{
    public Hp () { }
    public Hp(int maxHp)
    {
        Min = Constants.DefaultMinHp;
        Max = maxHp;
        Current = Max;
    }

    public override int ResetValue => Max;

    /// <summary>
    /// Modify Hp, without exceeding Min or Max.
    /// </summary>
    /// <param name="amount">Amount to add</param>
    public new void Modify(int amount)
    {
        Current = Math.Clamp(Current + amount, Min, Max);
    }
}