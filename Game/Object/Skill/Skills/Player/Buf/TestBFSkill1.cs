using System;
using Goguma.Game.Console;

namespace Goguma.Game.Object.Skill.Skills.Player.Buf
{
  [Serializable]
  public class TestBFSkill1 : BuffSkill
  {
    public override string Name => "조금 쌔지는 테스트 버프 스킬";

    public override CTexts Text => CTexts.Make("{나 자신 강해져라 ..!!}");

    public override CTexts Descriptions => CTexts.Make("{제작자가 테스트용으로 쓰는 버프 스킬이다.}");

    public override double UseEp => 6;

    public override Buff buff => new()
    {
      MaxHp = 20,
      PhysicalDamage = 5,
      PhysicalDefense = 0.4,
      turn = 5,
      Hp = 20
    };
  }
}