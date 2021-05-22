using System;
using Colorify;
using Goguma.Game.Console;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Skill
{
  [Serializable]
  class AttackSkill : Skill, IAttackSkill
  {
    public double Damage { get; set; }
    public double IgnoreDef { get => ignoreDef; set => Math.Max(0, value); }

    public override SkillType Type { get => SkillType.AttackSkill; }

    private double ignoreDef;

    public override void Information(bool isPause = true)
    {
      PrintText(GetSep(30, base.Name));
      PrintCText($"{{\n{Skill.GetTypeString(Type)} 스킬,{Colors.txtWarning}}}");
      PrintCText($"{{\n필요 에너지: }}{{{base.UseEp}\n, {Colors.txtWarning}}}");
      PrintText(GetSep(30) + "\n");
      PrintCText(base.Descriptions);
      PrintText("\n" + GetSep(30));
      PrintCText("{\n스킬 공격력: [ }");
      PrintCText(NumberColor(Damage));
      PrintCText("{ ]}");
      PrintCText("{\n방어율 무시: [ }");
      PrintCText(NumberColor(IgnoreDef));
      PrintCText("{ ]\n}");
      PrintText(GetSep(30));
      if (isPause) Pause();
    }
  }
}