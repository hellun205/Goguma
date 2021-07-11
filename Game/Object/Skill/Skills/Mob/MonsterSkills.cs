using System;

namespace Goguma.Game.Object.Skill.Skills
{
  public static partial class MonsterSkills
  {
    public static ISkill GetNew(MSkillList skill)
    {
      switch (skill)
      {
        case MSkillList.TESTMONSTER_TEST_PUNCH: return new Mob.TestMonster.TestPunch();

        case MSkillList.TESTMONSTER_TEST_FIREBALL: return new Mob.TestMonster.Fireball();

        case MSkillList.TESTMONSTER_TEST_ATTACK_SKILL: return new Mob.TestMonster.JustAttack();

        case MSkillList.TESTMONSTER_DEFENSIVE_POSTURE: return new Mob.TestMonster.DefensivePosture();

        case MSkillList.SLIME_STICKY_ATTACK: return new Mob.Slime.StickyAttack();

        case MSkillList.SLIME_SPOUT_STICKY_LIQUID: return new Mob.Slime.SpoutStickyLiquid();

        case MSkillList.GOLD_GOBLIN_SWORD_SWING:
          return new Mob.GoldGoblin.SwingSword
();

        case MSkillList.GOLD_GOBLIN_SWORD_STING: return new Mob.GoldGoblin.StingSword();

        case MSkillList.GOLD_GOBLIN_ANGER: return new Mob.GoldGoblin.Anger();

        default: throw new NotImplementedException();
      }
    }

    public static ISkill GetInstance(MSkillList skill)
    {
      switch (skill)
      {
        case MSkillList.TESTMONSTER_TEST_PUNCH: return TestMonster_TestPunch;

        case MSkillList.TESTMONSTER_TEST_FIREBALL: return TestMonster_Fireball;

        case MSkillList.TESTMONSTER_TEST_ATTACK_SKILL: return TestMonster_JustAttack;

        case MSkillList.TESTMONSTER_DEFENSIVE_POSTURE: return TestMonster_DefensivePosture;

        case MSkillList.SLIME_STICKY_ATTACK: return Slime_StickyAttack;

        case MSkillList.SLIME_SPOUT_STICKY_LIQUID: return Slime_SpoutStickyLiquid;

        case MSkillList.GOLD_GOBLIN_SWORD_SWING: return GoldGoblin_SwingSword;

        case MSkillList.GOLD_GOBLIN_SWORD_STING: return GoldGoblin_StingSword;

        case MSkillList.GOLD_GOBLIN_ANGER: return GoldGoblin_Anger;

        default: throw new NotImplementedException();
      }
    }
  }
}