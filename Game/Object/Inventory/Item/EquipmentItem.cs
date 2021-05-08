using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Inventory;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Inventory.Item
{
  [Serializable]
  class EquipmentItem : Item, IEquipmentItem
  {

    public EquipmentType EquipmentType { get; set; }
    public ItemIncrease Increase { get; set; }

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
        PrintText(CTexts.Make("{% ]}"));
      }
      //TODO
    }

    new public void UseItem(IPlayer player)
    {
      //TODO
    }
  }
}