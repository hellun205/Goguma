using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Skill.Attack;

namespace Goguma.Game.Object.Skill.Skills.Mob.TestMonster
{
  [Serializable]
  public class TestPunch : APhysicalAttackSkill
  {
    public override string Name => "테스트 펀치";

    public override CTexts Text => CTexts.Make("{테슷!!}}");

    public override CTexts Descriptions => CTexts.Make("{테스트 몬스터가 사용하는 테스트 공격이다.}}");

    public override AttackEffect Effect => new()
    {
      PhysicalDamage = 1,
      PhysicalPenetration = 1,
      CriticalDamage = 10,
      CriticalPercent = 50
    };
  }
}