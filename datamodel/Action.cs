namespace dnd_allies;

public class Action
{
    public Action()
    {
        
    }

    public string Name { get; set; } = "";

    public string Description { get; set; } = "";

    public SavingThrow SavingThrow { get; set; } = new SavingThrow();
}