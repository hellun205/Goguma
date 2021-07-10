using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Equipment;

namespace Goguma.Game.Object.Skill.Skills.Player.Attack
{
  [Serializable]
  public class TestATSkill2 : AttackSkill
  {
    public override string Name => "조금 강력한 테스트 공격 스킬";

    public override CTexts Text => CTexts.Make("{테스트용으로 공격하기 버전 2!}");

    public override CTexts Descriptions => CTexts.Make("{제작자가 테스트용으로 쓰는 공격 스킬이다.}");

    public override double UseEp => 6;

    public override WeaponEffect Effect => new()
    {
      AttDmg = 7,
      CritDmg = 5,
      CritPer = 5,
      IgnoreDef = 2
    };
  }
}