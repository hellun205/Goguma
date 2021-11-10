using System;

namespace Goguma.Game.Object.Skill.Skills
{
  public static partial class MonsterSkills
  {
    public static ISkill GetNew(MSkillList skill)
    {
      switch (skill)
      {
        case MSkillList.TestmonsterTestPunch: return new Mob.TestMonster.TestPunch();

        case MSkillList.TestmonsterTestFireball: return new Mob.TestMonster.Fireball();

        case MSkillList.TestmonsterTestAttackSkill: return new Mob.TestMonster.JustAttack();

        case MSkillList.TestmonsterDefensivePosture: return new Mob.TestMonster.DefensivePosture();

        case MSkillList.SlimeStickyAttack: return new Mob.Slime.StickyAttack();

        case MSkillList.SlimeSpoutStickyLiquid: return new Mob.Slime.SpoutStickyLiquid();

        case MSkillList.GoldGoblinSwordSwing:
          return new Mob.GoldGoblin.SwingSword
();

        case MSkillList.GoldGoblinSwordSting: return new Mob.GoldGoblin.StingSword();

        case MSkillList.GoldGoblinAnger: return new Mob.GoldGoblin.Anger();

        default: throw new NotImplementedException();
      }
    }

    public static ISkill GetInstance(MSkillList skill)
    {
      switch (skill)
      {
        case MSkillList.TestmonsterTestPunch: return TestMonsterTestPunch;

        case MSkillList.TestmonsterTestFireball: return TestMonsterFireball;

        case MSkillList.TestmonsterTestAttackSkill: return TestMonsterJustAttack;

        case MSkillList.TestmonsterDefensivePosture: return TestMonsterDefensivePosture;

        case MSkillList.SlimeStickyAttack: return SlimeStickyAttack;

        case MSkillList.SlimeSpoutStickyLiquid: return SlimeSpoutStickyLiquid;

        case MSkillList.GoldGoblinSwordSwing: return GoldGoblinSwingSword;

        case MSkillList.GoldGoblinSwordSting: return GoldGoblinStingSword;

        case MSkillList.GoldGoblinAnger: return GoldGoblinAnger;

        default: throw new NotImplementedException();
      }
    }
  }
}