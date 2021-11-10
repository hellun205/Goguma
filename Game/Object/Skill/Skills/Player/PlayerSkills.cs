using System;

namespace Goguma.Game.Object.Skill.Skills
{
  public static partial class PlayerSkills
  {
    public static ISkill GetNew(SkillList skill)
    {
      switch (skill)
      {
        case SkillList.TestSkill1: return new Player.Attack.TestAtSkill1();

        case SkillList.TestSkill2: return new Player.Attack.TestAtSkill2();

        case SkillList.TestBuffSkill1: return new Player.Buff.TestBfSkill1();

        default: throw new NotImplementedException();
      }
    }

    public static ISkill GetInstance(SkillList skill)
    {
      switch (skill)
      {
        case SkillList.TestSkill1: return TestAtSkill1;

        case SkillList.TestSkill2: return TestAtSkill2;

        case SkillList.TestBuffSkill1: return TestBfSkill1;

        default: throw new NotImplementedException();
      }
    }


  }
}