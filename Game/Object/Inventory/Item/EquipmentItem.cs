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
    new public int Count => 1;
    public override int MaxCount => 1;
    public WearingType EquipmentType { get; set; }
    public ItemIncrease Increase { get; set; }
    public override HavingType Type => HavingType.Equipment;
    public EquipmentItem()
    {

    }
    public EquipmentItem(EquipmentItem item) : this()
    {
      Name = item.Name;
    }
    static public IEquipmentItem GetAir()
    {
      return new EquipmentItem { IsAir = true };
    }
    public override void DescriptionItem()
    {
      var player = InGame.player;
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

    new public IItem GetInstance()
    {
      return new EquipmentItem(this);
    }

    public override void UseItem(IPlayer player)
    {

    }
  }
}