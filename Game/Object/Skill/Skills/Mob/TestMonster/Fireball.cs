using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Skill.Attack;

namespace Goguma.Game.Object.Skill.Skills.Mob.TestMonster
{
  [Serializable]
  public class Fireball : AMagicAttackSkill
  {
    public override string Name => "파이어 볼";

    public override CTexts Text => CTexts.Make("{빠이아 뽈!!}");

    public override CTexts Descriptions => CTexts.Make("{테스트 몬스터가 사용하는 화염구 공격이다.}}");

    public override AttackEffect Effect => new()
    {
      MagicDamage = 1,
      MagicPenetration = 1
    };
  }
}