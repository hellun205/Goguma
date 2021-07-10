using Goguma.Game.Console;

namespace Goguma.Game.Object.Skill.Skills.Mob.GoldGoblin
{
  public class Anger : BuffSkill
  {
    public override string Name => "분노";

    public override CTexts Text => CTexts.Make("{....!}");

    public override CTexts Descriptions => CTexts.Make("{황금 고블린이 분노하여 방어율은 감소하지만, 공격력 크게 증가한다.}}");

    public override Buff buff => new()
    {
      AttDmg = 7.1,
      DefPer = -16.5,
      CritDmg = 30,
      CritPer = 40,
      turn = 10
    };
  }
}