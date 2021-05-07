using System.Collections.Generic;
using Goguma.Game.Object.Enum;
using Goguma.Game.Object.Interface;

namespace Goguma.Game.Object.Inventory
{
  class InvenInfo
  {
    public string TypeString { get; set; }
    public List<IItem> TypeItems { get; set; }
    public ItemType ItemType { get; set; }


    public InvenInfo(Inventory inventory, ItemType itemType)
    {
      ItemType = ItemType;

      switch (itemType)
      {
        case ItemType.Equipment:
          TypeString = "장비";
          TypeItems = inventory.EquipmentItems;
          break;

        case ItemType.Consume:
          TypeString = "소비";
          TypeItems = inventory.ConsumeItems;
          break;

        case ItemType.Other:
          TypeString = "기타";
          TypeItems = inventory.OtherItems;
          break;
      }
    }
  }
}
