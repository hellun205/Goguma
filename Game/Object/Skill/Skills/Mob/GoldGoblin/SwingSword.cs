using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Equipment;

namespace Goguma.Game.Object.Skill.Skills.Mob.GoldGoblin
{
  public class SwingSword : AttackSkill
  {
    public override string Name => "스윙";

    public override CTexts Text => CTexts.Make("{...}");

    public override CTexts Descriptions => CTexts.Make("{황금 고블린이 적에게 검을 휘두른다.}");

    public override WeaponEffect Effect => new()
    {
      AttDmg = 3.2,
      IgnoreDef = 0.2,
      CritDmg = 15,
      CritPer = 10
    };
  }
}