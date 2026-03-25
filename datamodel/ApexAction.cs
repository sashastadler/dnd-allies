namespace dnd_allies;

public class ApexAction : Action
{
    public ApexAction() : base()
    { 
    }

    private int TimesUsed { get; set; }

    public bool CanUse => TimesUsed <= 0;
}