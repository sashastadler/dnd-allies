namespace dnd_allies;

public class Ally
{
    public Ally()
    { }

    public Hp? Hp { get; set; } = null;

    public int Ac { get; set; } = Constants.DefaultAc;

    public int Speed { get; set; } = Constants.DefaultSpeed;

    public string Name { get; set; } = Constants.Empty;

    public string Description { get; set; } = Constants.Empty;

    public List<Action> Actions { get; set; } = [];

    public List<string> Immunities { get; set; } = [];

    public ApexAction? Apex = null;
}