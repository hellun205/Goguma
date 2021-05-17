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

    public override void Information()
    {
      PrintText(GetSep(30, base.Name));
      PrintText(CTexts.Make($"{{\n{Skill.GetTypeString(Type)} 스킬,{Colors.txtWarning}}}"));
      PrintText(CTexts.Make($"{{\n필요 에너지: }}{{{base.useEp}\n, {Colors.txtWarning}}}"));
      PrintText(GetSep(30) + "\n");
      PrintText(base.Descriptions);
      PrintText("\n" + GetSep(30));
      PrintText(CTexts.Make("{\n스킬 공격력: [ }"));
      PrintText(NumberColor(Damage));
      PrintText(CTexts.Make("{ ]}"));
      PrintText(CTexts.Make("{\n방어율 무시: [ }"));
      PrintText(NumberColor(IgnoreDef));
      PrintText(CTexts.Make("{ ]\n}"));
      PrintText(GetSep(30));
      Pause();
    }
  }
}