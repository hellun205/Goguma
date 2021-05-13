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
            useEp = 2,
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
            useEp = 4,
            Damage = 7,
            IgnoreDef = 0
          };
          break;
        case SkillList.TestBuffSkill1:
          resultSkill = new BuffSkill()
          {
            Name = "테스트 버프 스킬1",
            Text = CTexts.Make("{테스트 버프 !!!!!!!}"),
            Type = SkillType.AttackSkill,
            useEp = 10,
            buff = new Buff()
            {
              MaxHp = 20,
              MaxEp = 0,
              AttDmg = 5,
              DefPer = 0.4,
              turn = 5
            }
          };
          break;
        default:
          return null;
      }
      return resultSkill;
    }
  }
}