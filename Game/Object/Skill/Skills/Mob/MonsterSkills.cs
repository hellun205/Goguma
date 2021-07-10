using System;

namespace Goguma.Game.Object.Skill.Skills
{
  public static partial class MonsterSkills
  {
    public static ISkill GetNew(MSkillList skill)
    {
      switch (skill)
      {
        case MSkillList.TestMonster_TestPunch: return new Mob.TestMonster.TestPunch();

        case MSkillList.TestMonster_TestFireBall: return new Mob.TestMonster.Fireball();

        case MSkillList.TestMonster_TestAttackSkill: return new Mob.TestMonster.JustAttack();

        case MSkillList.TestMonster_DefensivePosture: return new Mob.TestMonster.DefensivePosture();

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
        case MSkillList.TestMonster_TestPunch: return TestMonster_TestPunch;

        case MSkillList.TestMonster_TestFireBall: return TestMonster_Fireball;

        case MSkillList.TestMonster_TestAttackSkill: return TestMonster_JustAttack;

        case MSkillList.TestMonster_DefensivePosture: return TestMonster_DefensivePosture;

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