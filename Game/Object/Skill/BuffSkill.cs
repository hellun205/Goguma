using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Skill
{
  [Serializable]
  class BuffSkill : Skill, IBuffSkill
  {
    public Buff buff { get; set; }
    public override SkillType Type { get => SkillType.BuffSkill; }

    public override void Information(bool isPause = true)
    {
      IPlayer player = InGame.player;
      PrintText(GetSep(30, base.Name));
      PrintCText($"{{\n{Skill.GetTypeString(Type)} 스킬,{Colors.txtWarning}}}");
      PrintCText($"{{\n필요 에너지: }}{{{base.UseEp}\n, {Colors.txtWarning}}}");
      PrintText(GetSep(30) + "\n");
      PrintCText(base.Descriptions);
      PrintText("\n" + GetSep(30));
      if (buff.MaxHp != 0)
      {
        PrintCText($"{{\n최대 체력 증가: }} {{{player.MaxHp}, {Colors.txtWarning}}} {{ [ }}");
        PrintCText(NumberColor(buff.MaxHp));
        PrintCText("{ ] → }");
        PrintCText(NumberColor(buff.MaxHp + player.MaxHp));
      }
      if (buff.Hp != 0)
      {
        PrintCText($"{{\n체력 증가: }} {{{player.Hp}, {Colors.txtWarning}}} {{ % [ }}");
        PrintCText(NumberColor(buff.Hp));
        PrintCText("{ % ] → }");
        PrintCText(NumberColor(buff.Hp + player.Hp));
        PrintCText("{ %\n}");
      }
      if (buff.MaxEp != 0)
      {
        PrintCText($"{{\n최대 에너지 증가: }} {{{player.MaxEp}, {Colors.txtWarning}}} {{ [ }}");
        PrintCText(NumberColor(buff.MaxEp));
        PrintCText("{ ] → }");
        PrintCText(NumberColor(buff.MaxEp + player.MaxEp));
      }
      if (buff.Ep != 0)
      {
        PrintCText($"{{\n에너지 증가: }} {{{player.DefPer}, {Colors.txtWarning}}} {{ % [ }}");
        PrintCText(NumberColor(buff.Ep));
        PrintCText("{ % ] → }");
        PrintCText(NumberColor(buff.Ep + player.Ep));
        PrintCText("{ %\n}");
      }
      if (buff.AttDmg != 0)
      {
        PrintCText($"{{\n공격력 증가: }} {{{player.AttDmg}, {Colors.txtWarning}}} {{ [ }}");
        PrintCText(NumberColor(buff.AttDmg));
        PrintCText("{ ] → }");
        PrintCText(NumberColor(buff.AttDmg + player.AttDmg));
      }
      if (buff.DefPer != 0)
      {
        PrintCText($"{{\n방어율 증가: }} {{{player.DefPer}, {Colors.txtWarning}}} {{ % [ }}");
        PrintCText(NumberColor(buff.DefPer));
        PrintCText("{ % ] → }");
        PrintCText(NumberColor(buff.DefPer + player.DefPer));
        PrintCText("{ %\n}");
      }
      PrintText(GetSep(30) + "\n");
      if (isPause) Pause();
    }
  }
}