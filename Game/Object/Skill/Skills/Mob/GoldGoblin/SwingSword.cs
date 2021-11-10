using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Equipment;
using Goguma.Game.Object.Skill.Attack;

namespace Goguma.Game.Object.Skill.Skills.Mob.GoldGoblin
{
  [Serializable]
  public class SwingSword : APhysicalAttackSkill
  {
    public override string Name => "스윙";

    public override CTexts Text => CTexts.Make("{...}");

    public override CTexts Descriptions => CTexts.Make("{황금 고블린이 적에게 검을 휘두른다.}");

    public override AttackEffect Effect => new()
    {
      PhysicalDamage = 3.2,
      PhysicalPenetration = 0.2,
      CriticalDamage = 15,
      CriticalPercent = 10
    };
  }
}