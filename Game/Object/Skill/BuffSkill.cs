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
      PrintText(CTexts.Make($"{{\n{Skill.GetTypeString(Type)} 스킬,{Colors.txtWarning}}}"));
      PrintText(CTexts.Make($"{{\n필요 에너지: }}{{{base.useEp}\n, {Colors.txtWarning}}}"));
      PrintText(GetSep(30) + "\n");
      PrintText(base.Descriptions);
      PrintText("\n" + GetSep(30));
      if (buff.MaxHp != 0)
      {
        PrintText(CTexts.Make($"{{\n최대 체력 증가: }} {{{player.MaxHp}, {Colors.txtWarning}}} {{ [ }}"));
        PrintText(NumberColor(buff.MaxHp));
        PrintText(CTexts.Make("{ ] → }"));
        PrintText(NumberColor(buff.MaxHp + player.MaxHp));
      }
      if (buff.Hp != 0)
      {
        PrintText(CTexts.Make($"{{\n체력 증가: }} {{{player.Hp}, {Colors.txtWarning}}} {{ % [ }}"));
        PrintText(NumberColor(buff.Hp));
        PrintText(CTexts.Make("{ % ] → }"));
        PrintText(NumberColor(buff.Hp + player.Hp));
        PrintText(CTexts.Make("{ %\n}"));
      }
      if (buff.MaxEp != 0)
      {
        PrintText(CTexts.Make($"{{\n최대 에너지 증가: }} {{{player.MaxEp}, {Colors.txtWarning}}} {{ [ }}"));
        PrintText(NumberColor(buff.MaxEp));
        PrintText(CTexts.Make("{ ] → }"));
        PrintText(NumberColor(buff.MaxEp + player.MaxEp));
      }
      if (buff.Ep != 0)
      {
        PrintText(CTexts.Make($"{{\n에너지 증가: }} {{{player.DefPer}, {Colors.txtWarning}}} {{ % [ }}"));
        PrintText(NumberColor(buff.Ep));
        PrintText(CTexts.Make("{ % ] → }"));
        PrintText(NumberColor(buff.Ep + player.Ep));
        PrintText(CTexts.Make("{ %\n}"));
      }
      if (buff.AttDmg != 0)
      {
        PrintText(CTexts.Make($"{{\n공격력 증가: }} {{{player.AttDmg}, {Colors.txtWarning}}} {{ [ }}"));
        PrintText(NumberColor(buff.AttDmg));
        PrintText(CTexts.Make("{ ] → }"));
        PrintText(NumberColor(buff.AttDmg + player.AttDmg));
      }
      if (buff.DefPer != 0)
      {
        PrintText(CTexts.Make($"{{\n방어율 증가: }} {{{player.DefPer}, {Colors.txtWarning}}} {{ % [ }}"));
        PrintText(NumberColor(buff.DefPer));
        PrintText(CTexts.Make("{ % ] → }"));
        PrintText(NumberColor(buff.DefPer + player.DefPer));
        PrintText(CTexts.Make("{ %\n}"));
      }
      PrintText(GetSep(30) + "\n");
      if (isPause) Pause();
    }
  }
}