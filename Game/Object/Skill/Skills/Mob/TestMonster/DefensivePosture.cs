using System;
using Goguma.Game.Console;

namespace Goguma.Game.Object.Skill.Skills.Mob.TestMonster
{
  [Serializable]
  public class DefensivePosture : BuffSkill
  {
    public override string Name => "방어 태세";

    public override CTexts Text => CTexts.Make("{방어 태세 !}}}");

    public override CTexts Descriptions => CTexts.Make("{테스트 몬스터가 자신의 체력이 낮아지면 사용하는 버프 스킬이다.}}}");

    public override Buff buff => new()
    {
      PhysicalDamage = -5,
      PhysicalDefense = 50,
      turn = 5
    };
  }
}