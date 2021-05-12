using Goguma.Game.Console;

namespace Goguma.Game.Object.Skill
{
  static class Skills
  {
    static public ISkill Get(SkillList skill)
    {
      ISkill resultSkill;
      switch (skill)
      {
        case SkillList.TestSkill1:
          resultSkill = new AttackSkill()
          {
            Name = "테스트 스킬1",
            Text = CTexts.Make("{테스테스트!}"),
            Type = SkillType.AttackSkill,
            Damage = 5,
            IgnoreDef = 0
          };
          break;
        case SkillList.TestSkill2:
          resultSkill = new AttackSkill()
          {
            Name = "테스트 스킬2",
            Text = CTexts.Make("{테스테스테스트!}"),
            Type = SkillType.AttackSkill,
            Damage = 7,
            IgnoreDef = 0
          };
          break;
        default:
          return null;
      }
      return resultSkill;
    }
  }
}