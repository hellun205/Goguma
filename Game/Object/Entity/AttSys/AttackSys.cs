using Goguma.Game.Object.Skill;

namespace Goguma.Game.Object.Entity.AttSys
{
  public class AttackSys
  {
    public ISkill SkillToUse { get; set; }
    public AttCondition Condition { get; set; }
    public AttackSys(ISkill skill, AttCondition ac)
    {
      SkillToUse = skill;
      Condition = ac;
    }
  }
}
