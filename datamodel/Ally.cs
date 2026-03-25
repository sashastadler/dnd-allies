namespace dnd_allies;

public class Ally
{
    public Ally()
    {
        HpCurrent = HpMax;
    }

    public int HpMax { get; set; } = 99;

    public int HpCurrent { get; set; } = 99;

    public string Name { get; set; } = "";

    public string Description { get; set; } = "";

    public List<Action> Actions { get; set; } = [];

    public List<string> Immunities { get; set; } = [];

    public ApexAction? Apex = null;
}