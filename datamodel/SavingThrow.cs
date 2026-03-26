namespace dnd_allies;
public class SavingThrow
{
    public SavingThrow()
    {
        Difficulty = 0;
        Skill = SkillType.None;
    }
    public SavingThrow(int dc, SkillType type)
    {
        Difficulty = dc;
        Skill = type;
    }
    public int Difficulty { get; set; } = 0;
    public SkillType Skill { get; set; } = SkillType.None;

}
public enum SkillType
{
    None,
    Wisdom,
    Charisma,
    Intelligence,
    Strength,
    Constitution,
    Dexterity
}