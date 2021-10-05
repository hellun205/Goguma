using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Equipment;

namespace Goguma.Game.Object.Skill.Skills.Mob.Slime
{
  [Serializable]
  public class SpoutStickyLiquid : AttackSkill
  {
    public override string Name => "끈적한 액체 내뿜기";

    public override CTexts Text => CTexts.Make("{(쮸우욱 쭈욱..)}");

    public override CTexts Descriptions => CTexts.Make("{슬라임의 역겨운 공격2}");

    public override WeaponEffect Effect => new()
    {
      PhysicalDamage = 2.7,
      PhysicalPenetration = 0.3
    };
  }
}