namespace dnd_allies;

public class Ally
{
    public Ally()
    {
        Ac = 99;
        Speed = 99;
        Name = "";
        HpMax = 99;
        HpCurrent = HpMax;
    }

    public int HpMax { get; set; }

    public int HpCurrent { get; set; }

    public int Ac { get; set; }

    public int Speed { get; set; }

    public string Name { get; set; } = "";

    public string Description { get; set; } = "";

    public List<Action> Actions { get; set; } = [];

    public List<string> Immunities { get; set; } = [];

    public ApexAction? Apex = null;
}