using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goguma.Game.Object.Enum;
using Goguma.Game.Object.Interface;

namespace Goguma.Game.Object.Inventory
{
  class ItemOptionInfo
  {
    private Inventory MyInventory { get; set; }
    private InvenInfo MyInvenInfo { get; set; }
    private ItemInfo MyItemInfo { get; set; }
    private int SelectedItemIndex { get; set; }
    private string OptionText { get; set; }

    private IItem SelectedItem { get; set; }

    public ItemOptionInfo(Inventory inventory, ItemType itemType, int selectedItemIndex, string optionText)
    {
      MyInventory = inventory;
      MyInvenInfo = new InvenInfo(inventory, itemType);
      MyItemInfo = new ItemInfo(itemType);
      SelectedItemIndex = selectedItemIndex;
      OptionText = optionText;

      SelectedItem = MyInvenInfo.TypeItems[SelectedItemIndex];
    }

    public void Act()
    {
      switch (OptionText)
      {
        case "아이템 정보 보기":

          break;

        default:
          break;

      }
    }

    private void Consume()
    {
      
    }
  }
}
