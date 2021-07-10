using System;

namespace Goguma.Game.Object.Skill.Skills
{
  public static partial class PlayerSkills
  {
    public static ISkill GetNew(SkillList skill)
    {
      switch (skill)
      {
        case SkillList.TestSkill1: return new Player.Attack.TestATSkill1();

        case SkillList.TestSkill2: return new Player.Attack.TestATSkill2();

        case SkillList.TestBuffSkill1: return new Player.Buf.TestBFSkill1();

        default: throw new NotImplementedException();
      }
    }

    public static ISkill GetInstance(SkillList skill)
    {
      switch (skill)
      {
        case SkillList.TestSkill1: return TestATSkill1;

        case SkillList.TestSkill2: return TestATSkill2;

        case SkillList.TestBuffSkill1: return TestBFSkill1;

        default: throw new NotImplementedException();
      }
    }
  }
}