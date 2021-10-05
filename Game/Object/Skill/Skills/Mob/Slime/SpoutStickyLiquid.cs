using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Skill.Attack;

namespace Goguma.Game.Object.Skill.Skills.Mob.Slime
{
  [Serializable]
  public class SpoutStickyLiquid : AMagicAttackSkill
  {
    public override string Name => "끈적한 액체 내뿜기";

    public override CTexts Text => CTexts.Make("{(쮸우욱 쭈욱..)}");

    public override CTexts Descriptions => CTexts.Make("{슬라임의 역겨운 공격2}");

    public override AttackEffect Effect => new()
    {
      MagicDamage = 2.7,
      MagicPenetration = 0.3
    };
  }
}