using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Inventory.Item.Consume
{
  [Serializable]
  class CPotion : ConsumeItem
  {
    public ItemEffect Effect { get; set; }
    public override string GetString => "포션";
    public CPotion() : base() { }
    public CPotion(in CPotion item) : base(item)
    {
      Effect = item.Effect;
    }
    public override void DescriptionItem()
    {
      var player = InGame.player;
      if (Effect.Hp != 0)
      {
        PrintCText($"{{\nHP }} {{{player.Hp} / {player.MaxHp}, {Colors.txtWarning}}} {{ [ }}");
        PrintCText(NumberColor(Effect.Hp));
        PrintCText("{ ] → }");
        if (Effect.Hp + player.Hp <= player.MaxHp)
          PrintCText(NumberColor(Effect.Hp + player.Hp));
        else
          PrintCText(NumberColor(player.MaxHp));
      }
      if (Effect.Ep != 0)
      {
        PrintCText($"{{\nEP }} {{{player.Ep} / {player.MaxEp}, {Colors.txtWarning}}} {{ [ }}");
        PrintCText(NumberColor(Effect.Ep));
        PrintCText("{ ] → }");
        if (Effect.Ep + player.Ep <= player.MaxEp)
          PrintCText(NumberColor(Effect.Ep + player.Ep));
        else
          PrintCText(NumberColor(player.MaxEp));
      }
      if (Effect.AttDmg != 0)
      {
        PrintCText($"{{\nATT }} {{{player.AttDmg}, {Colors.txtWarning}}} {{ [ }}");
        PrintCText(NumberColor(Effect.AttDmg));
        PrintCText("{ ] → }");
        PrintCText(NumberColor(Effect.AttDmg + player.AttDmg));
      }
      if (Effect.DefPer != 0)
      {
        PrintCText($"{{\nDEF }} {{{player.DefPer}, {Colors.txtWarning}}} {{ % [ }}");
        PrintCText(NumberColor(Effect.DefPer));
        PrintCText("{ % ] → }");
        PrintCText(NumberColor(Effect.DefPer + player.DefPer));
        PrintCText("{ %}");
      }
      if (Effect.Gold != 0)
      {
        PrintCText($"{{\nGOLD }} {{{player.Gold}, {Colors.txtWarning}}} {{ G [ }}");
        PrintCText(NumberColor(Effect.Gold));
        PrintCText("{ G ] → }");
        PrintCText(NumberColor(Effect.Gold + player.Gold));
        PrintCText("{ G}");
      }
      if (Effect.Exp != 0)
      {
        PrintCText($"{{\nEXP }} {{{player.Exp} / {player.MaxExp}, {Colors.txtWarning}}} {{ [ }}");
        PrintCText(NumberColor(Effect.Exp));
        PrintCText("{ ] → }");
        PrintCText(NumberColor(Effect.Exp + player.Exp));
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
    public override IItem GetInstance()
    {
      return new CPotion(this);
    }

  }
}