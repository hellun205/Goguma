using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goguma.Game.Console;
using Goguma.Game.Object.Enum;
using Goguma.Game.Object.Interface;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game.Object.Inventory
{
  class InvenInfo
  {
    public string TypeString { get; set; }
    public List<IItem> TypeItem { get; set; }


    public InvenInfo(Inventory inventory, ItemType itemType)
    {
      switch (itemType)
      {
        case ItemType.Equipment:
          TypeString = "장비";
          TypeItem = inventory.EquipmentItems;
          break;

        case ItemType.Consume:
          TypeString = "소비";
          TypeItem = inventory.ConsumeItems;
          break;

        case ItemType.Other:
          TypeString = "기타";
          TypeItem = inventory.OtherItems;
          break;

      }
    }
  }
}
