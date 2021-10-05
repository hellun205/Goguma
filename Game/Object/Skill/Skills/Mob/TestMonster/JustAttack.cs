using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Skill.Attack;

namespace Goguma.Game.Object.Skill.Skills.Mob.TestMonster
{
  [Serializable]
  public class JustAttack : APhysicalAttackSkill
  {
    public override string Name => "그냥 공격";

    public override CTexts Text => CTexts.Make("{으아아앙락ㅇ}}");

    public override CTexts Descriptions => CTexts.Make("{테스트 몬스터가 사용하는 그냥 공격 스킬이다.}}");

    public override AttackEffect Effect => new()
    {
      PhysicalDamage = 2
    };
  }
}