using System;
using Colorify;
using Goguma.Game.Console;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  [Serializable]
  class EquipmentItem : Item, IEquipmentItem
  {
    public override HavingType Type => HavingType.Equipment;
    public override int MaxCount => 1;
    public WearingType EquipmentType { get; set; }
    public ItemIncrease Increase { get; set; }
    public EquipmentItem() : base() { }
    public EquipmentItem(in EquipmentItem item) : base(item)
    {
      EquipmentType = item.EquipmentType;
      Increase = item.Increase;
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
        PrintCText($"{{\nMAX HP }} {{{player.MaxHp}, {Colors.txtWarning}}} {{ [ }}");
        PrintCText(NumberColor(Increase.MaxHp));
        PrintCText("{ ] → }");
        PrintCText(NumberColor(Increase.MaxHp + player.MaxHp));
      }
      if (Increase.MaxEp != 0)
      {
        PrintCText($"{{\nMAX EP }} {{{player.MaxEp}, {Colors.txtWarning}}} {{ [ }}");
        PrintCText(NumberColor(Increase.MaxEp));
        PrintCText("{ ] → }");
        PrintCText(NumberColor(Increase.MaxEp + player.MaxEp));
      }
      if (Increase.AttDmg != 0)
      {
        PrintCText($"{{\nATT }} {{{player.AttDmg}, {Colors.txtWarning}}} {{ [ }}");
        PrintCText(NumberColor(Increase.AttDmg));
        PrintCText("{ ] → }");
        PrintCText(NumberColor(Increase.AttDmg + player.AttDmg));
      }
      if (Increase.DefPer != 0)
      {
        PrintCText($"{{\nDEF }} {{{player.DefPer}, {Colors.txtWarning}}} {{ % [ }}");
        PrintCText(NumberColor(Increase.DefPer));
        PrintCText("{ % ] → }");
        PrintCText(NumberColor(Increase.DefPer + player.DefPer));
        PrintCText("{ %}");
      }
    }

    public override IItem GetInstance()
    {
      return new EquipmentItem(this);
    }
  }
}