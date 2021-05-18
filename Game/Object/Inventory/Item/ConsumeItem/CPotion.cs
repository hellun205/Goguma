using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Inventory.Item.ConsumeItem
{
  [Serializable]
  class CPotion : ConsumeItem, IItem
  {

    public ItemEffect Effect { get; set; }
    public CPotion() : base() { }
    public CPotion(CPotion item) : this()
    {
      Name = item.Name;
      Count = item.Count;
    }
    public override void DescriptionItem()
    {
      var player = InGame.player;
      if (Effect.Hp != 0)
      {
        PrintText(CTexts.Make($"{{\nHP }} {{{player.Hp} / {player.MaxHp}, {Colors.txtWarning}}} {{ [ }}"));
        PrintText(NumberColor(Effect.Hp));
        PrintText(CTexts.Make("{ ] → }"));
        if (Effect.Hp + player.Hp <= player.MaxHp)
          PrintText(NumberColor(Effect.Hp + player.Hp));
        else
          PrintText(NumberColor(player.MaxHp));
      }
      if (Effect.Ep != 0)
      {
        PrintText(CTexts.Make($"{{\nEP }} {{{player.Ep} / {player.MaxEp}, {Colors.txtWarning}}} {{ [ }}"));
        PrintText(NumberColor(Effect.Ep));
        PrintText(CTexts.Make("{ ] → }"));
        if (Effect.Ep + player.Ep <= player.MaxEp)
          PrintText(NumberColor(Effect.Ep + player.Ep));
        else
          PrintText(NumberColor(player.MaxEp));
      }
      if (Effect.AttDmg != 0)
      {
        PrintText(CTexts.Make($"{{\nATT }} {{{player.AttDmg}, {Colors.txtWarning}}} {{ [ }}"));
        PrintText(NumberColor(Effect.AttDmg));
        PrintText(CTexts.Make("{ ] → }"));
        PrintText(NumberColor(Effect.AttDmg + player.AttDmg));
      }
      if (Effect.DefPer != 0)
      {
        PrintText(CTexts.Make($"{{\nDEF }} {{{player.DefPer}, {Colors.txtWarning}}} {{ % [ }}"));
        PrintText(NumberColor(Effect.DefPer));
        PrintText(CTexts.Make("{ % ] → }"));
        PrintText(NumberColor(Effect.DefPer + player.DefPer));
        PrintText(CTexts.Make("{ %}"));
      }
      if (Effect.Gold != 0)
      {
        PrintText(CTexts.Make($"{{\nGOLD }} {{{player.Gold}, {Colors.txtWarning}}} {{ G [ }}"));
        PrintText(NumberColor(Effect.Gold));
        PrintText(CTexts.Make("{ G ] → }"));
        PrintText(NumberColor(Effect.Gold + player.Gold));
        PrintText(CTexts.Make("{ G}"));
      }
      if (Effect.Exp != 0)
      {
        PrintText(CTexts.Make($"{{\nEXP }} {{{player.Exp} / {player.MaxExp}, {Colors.txtWarning}}} {{ [ }}"));
        PrintText(NumberColor(Effect.Exp));
        PrintText(CTexts.Make("{ ] → }"));
        PrintText(NumberColor(Effect.Exp + player.Exp));
      }
    }

    public override void UseItem(IPlayer player)
    {
      player.Hp += Effect.Hp;
      player.Ep += Effect.Ep;
      player.AttDmg += Effect.AttDmg;
      player.DefPer += Effect.DefPer;
      player.Gold += Effect.Gold;
      player.Exp += Effect.Exp;
    }
    new public IItem GetInstance()
    {
      return new CPotion(this);
    }
  }
}