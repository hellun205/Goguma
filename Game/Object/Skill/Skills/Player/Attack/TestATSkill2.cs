using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Skill.Attack;

namespace Goguma.Game.Object.Skill.Skills.Player.Attack
{
  [Serializable]
  public class TestATSkill2 : APhysicalAttackSkill
  {
    public override string Name => "조금 강력한 테스트 공격 스킬";

    public override CTexts Text => CTexts.Make("{테스트용으로 공격하기 버전 2!}");

    public override CTexts Descriptions => CTexts.Make("{제작자가 테스트용으로 쓰는 공격 스킬이다.}");

    public override double UseEp => 6;

    public override AttackEffect Effect => new()
    {
      PhysicalDamage = 7,
      CriticalDamage = 5,
      CriticalPercent = 5,
      PhysicalPenetration = 2
    };
  }
}