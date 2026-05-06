namespace dnd_allies;

public class Ally
{
    public Ally()
    { }

    public Hp? Hp { get; set; } = null;

    public int? Ac { get; set; } = null;

    public string? Speed { get; set; } = null;

    public string Name { get; set; } = Constants.Empty;

    public string Description { get; set; } = Constants.Empty;

    public List<Action> Actions { get; set; } = [];

    public List<string> Immunities { get; set; } = [];

    public ApexAction? Apex { get; set; } = null;

    public Action? Innate { get; set; } = null;
}