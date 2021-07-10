using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Equipment;

namespace Goguma.Game.Object.Skill.Skills.Mob.TestMonster
{
  public class TestPunch : AttackSkill
  {
    public override string Name => "테스트 펀치";

    public override CTexts Text => CTexts.Make("{테슷!!}}");

    public override CTexts Descriptions => CTexts.Make("{테스트 몬스터가 사용하는 테스트 공격이다.}}");

    public override WeaponEffect Effect => new()
    {
      AttDmg = 1,
      IgnoreDef = 1
    };
  }
}