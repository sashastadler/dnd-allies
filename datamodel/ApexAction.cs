namespace dnd_allies;

public class ApexAction : Action
{
    public ApexAction() : base()
    { 
    }

    public string FlavorText { get; set; } = Constants.Empty;

    private int TimesUsed { get; set; } = 0;

    public bool CanUse => TimesUsed <= 0;

    public void Use() => TimesUsed++;
}