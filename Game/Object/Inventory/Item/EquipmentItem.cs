using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Inventory.Item
{
  [Serializable]
  class EquipmentItem : Item, IEquipmentItem
  {
    public WearingType EquipmentType { get; set; }
    public ItemIncrease Increase { get; set; }

    public EquipmentItem()
    {
      MaxCount = 1;
      Count = 1;

    }

    new static public IEquipmentItem GetAir()
    {
      IEquipmentItem resultItem = new EquipmentItem { IsAir = true };
      return resultItem;
    }

    new public void DescriptionItem()
    {
      if (Increase.MaxHp != 0)
      {
        PrintText(CTexts.Make("{\nMAX HP [ }"));
        PrintText(NumberColor(Increase.MaxHp));
        PrintText(CTexts.Make("{ ]}"));
      }
      if (Increase.MaxEp != 0)
      {
        PrintText(CTexts.Make("{  MAX EP [ }"));
        PrintText(NumberColor(Increase.MaxEp));
        PrintText(CTexts.Make("{ ]}"));
      }
      if (Increase.AttDmg != 0)
      {
        PrintText(CTexts.Make("{\nATT [ }"));
        PrintText(NumberColor(Increase.AttDmg));
        PrintText(CTexts.Make("{ ]}"));
      }
      if (Increase.DefPer != 0)
      {
        PrintText(CTexts.Make("{  DEF [ }"));
        PrintText(NumberColor(Increase.DefPer));
        PrintText(CTexts.Make("{ % ]}"));
      }
    }
    new public void DescriptionItemAP(IPlayer player)
    {
      if (Increase.MaxHp != 0)
      {
        PrintText(CTexts.Make($"{{\nMAX HP }} {{{player.MaxHp}, {Colors.txtWarning}}} {{ [ }}"));
        PrintText(NumberColor(Increase.MaxHp));
        PrintText(CTexts.Make("{ ] → }"));
        PrintText(NumberColor(Increase.MaxHp + player.MaxHp));
      }
      if (Increase.MaxEp != 0)
      {
        PrintText(CTexts.Make($"{{\nMAX EP }} {{{player.MaxEp}, {Colors.txtWarning}}} {{ [ }}"));
        PrintText(NumberColor(Increase.MaxEp));
        PrintText(CTexts.Make("{ ] → }"));
        PrintText(NumberColor(Increase.MaxEp + player.MaxEp));
      }
      if (Increase.AttDmg != 0)
      {
        PrintText(CTexts.Make($"{{\nATT }} {{{player.AttDmg}, {Colors.txtWarning}}} {{ [ }}"));
        PrintText(NumberColor(Increase.AttDmg));
        PrintText(CTexts.Make("{ ] → }"));
        PrintText(NumberColor(Increase.AttDmg + player.AttDmg));
      }
      if (Increase.DefPer != 0)
      {
        PrintText(CTexts.Make($"{{\nDEF }} {{{player.DefPer}, {Colors.txtWarning}}} {{ % [ }}"));
        PrintText(NumberColor(Increase.DefPer));
        PrintText(CTexts.Make("{ % ] → }"));
        PrintText(NumberColor(Increase.DefPer + player.DefPer));
        PrintText(CTexts.Make("{ %}"));
      }
    }

    new public void UseItem(IPlayer player)
    {

    }
  }
}