using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Equipment;

namespace Goguma.Game.Object.Skill.Skills.Player.Attack
{
  [Serializable]
  public class TestATSkill1 : AttackSkill
  {
    public override string Name => "테스트 공격 스킬1";

    public override CTexts Text => CTexts.Make("{테스트용으로 공격하기 버전 1!}");

    public override CTexts Descriptions => CTexts.Make("{제작자가 테스트용으로 쓰는 공격 스킬이다.}");

    public override double UseEp => 2;

    public override WeaponEffect Effect => new()
    {
      PhysicalDamage = 5
    };
  }
}