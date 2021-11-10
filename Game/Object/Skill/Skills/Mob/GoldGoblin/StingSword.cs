using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Equipment;
using Goguma.Game.Object.Skill.Attack;

namespace Goguma.Game.Object.Skill.Skills.Mob.GoldGoblin
{
  [Serializable]
  public class StingSword : APhysicalAttackSkill
  {
    public override string Name => "스팅";

    public override CTexts Text => CTexts.Make("{...}");

    public override CTexts Descriptions => CTexts.Make("{황금 고블린이 적의 급소를 정확히 찌른다.}}");

    public override AttackEffect Effect => new()
    {
      PhysicalDamage = 2.1,
      PhysicalPenetration = 10,
      CriticalDamage = 50,
      CriticalPercent = 70
    };
  }
}