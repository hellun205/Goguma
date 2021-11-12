using System;

namespace Goguma.Game.Object.Skill.Skills
{
  public static partial class PlayerSkills
  {
    public static ISkill GetNew(SkillList skill)
    {
      switch (skill)
      {
        case SkillList.TEST_SKILL1: return new Player.Attack.TestAtSkill1();

        case SkillList.TEST_SKILL2: return new Player.Attack.TestAtSkill2();

        case SkillList.TEST_BUFF_SKILL1: return new Player.Buff.TestBfSkill1();

        default: throw new NotImplementedException();
      }
    }

    public static ISkill GetInstance(SkillList skill)
    {
      switch (skill)
      {
        case SkillList.TEST_SKILL1: return TestAtSkill1;

        case SkillList.TEST_SKILL2: return TestAtSkill2;

        case SkillList.TEST_BUFF_SKILL1: return TestBfSkill1;

        default: throw new NotImplementedException();
      }
    }


  }
}