using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Equipment;

namespace Goguma.Game.Object.Skill.Skills.Mob.GoldGoblin
{
  public class StingSword : AttackSkill
  {
    public override string Name => "스팅";

    public override CTexts Text => CTexts.Make("{...}");

    public override CTexts Descriptions => CTexts.Make("{황금 고블린이 적의 급소를 정확히 찌른다.}}");

    public override WeaponEffect Effect => new()
    {
      AttDmg = 2.1,
      IgnoreDef = 10,
      CritDmg = 50,
      CritPer = 70
    };
  }
}