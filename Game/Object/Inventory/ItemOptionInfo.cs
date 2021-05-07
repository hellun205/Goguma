using Goguma.Game.Console;
using Goguma.Game.Object.Enum;
using Goguma.Game.Object.Interface;
using static Goguma.Game.Console.ConsoleFunction;
using Colorify;

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
          PrintText(SelectedItem.Name);          
          PrintText(CTexts.Make($"{{ [{SelectedItem.Count}],{Colors.txtInfo}}}"));
          PrintText(CTexts.Make($"{{\n {SelectedItem.Lore}, {Colors.txtMuted}}}"));
          Pause();
          break;
      }
    }

    private void Consume()
    {
      // TODO
    }
  }
}
