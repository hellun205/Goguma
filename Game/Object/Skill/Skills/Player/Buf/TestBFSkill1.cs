using Goguma.Game.Console;

namespace Goguma.Game.Object.Skill.Skills.Player.Buf
{
  public class TestBFSkill1 : BuffSkill
  {
    public override string Name => "조금 강력한 테스트 공격 스킬";

    public override CTexts Text => CTexts.Make("{테스트용으로 공격하기 버전 2!}");

    public override CTexts Descriptions => CTexts.Make("{제작자가 테스트용으로 쓰는 공격 스킬이다.}");

    public override double UseEp => 6;

    public override Buff buff => new()
    {
      MaxHp = 20,
      AttDmg = 5,
      DefPer = 0.4,
      turn = 5,
      Hp = 20
    };
  }
}