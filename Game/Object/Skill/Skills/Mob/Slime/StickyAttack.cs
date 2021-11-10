using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Skill.Attack;

namespace Goguma.Game.Object.Skill.Skills.Mob.Slime
{
  [Serializable]
  public class StickyAttack : AMagicAttackSkill
  {
    public override string Name => "끈적 공격";

    public override CTexts Text => CTexts.Make("{(쮸르륵쭈욱...)}");

    public override CTexts Descriptions => CTexts.Make("{슬라임의 역겨운 공격이다.}");

    public override AttackEffect Effect => new()
    {
      MagicDamage = 2
    };
  }
}