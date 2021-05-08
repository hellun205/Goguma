using Goguma.Game.Console;
using System;

using static Goguma.Game.Console.StringFunction;
using static Goguma.Game.Console.ConsoleFunction;
using Colorify;

namespace Goguma.Game.Object.Inventory.Item
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

    public void SelectedItemCTexts()
    {
      PrintText(CTexts.Make($"{{\n    선택 : }} {{{SelectedItem.Name.ToString()}}} {{ [{SelectedItem.Count}], {Colors.txtInfo}}} {{\n    위치 : }} {{{MyInvenInfo.TypeString},{Colors.txtSuccess}}} {{ . }} {{{SelectedItemIndex + 1},{Colors.txtSuccess}}}"));
    }

    public void Act()
    {
      switch (OptionText)
      {
        case "아이템 정보 보기": //All Item
          PrintText(SelectedItem.Name);
          PrintText(CTexts.Make($"{{ [{SelectedItem.Count}],{Colors.txtInfo}}}"));
          PrintText(CTexts.Make($"{{ {MyInvenInfo.TypeString} 아이템\n  , {Colors.txtWarning}}}"));
          PrintText(CTexts.Make($"{{{SelectedItem.Lore}, {Colors.txtMuted}}}"));
          PrintText("\n");
          PrintText(SelectedItem.Description);
          PrintText("\n");

          SelectedItem.DescriptionItem();
          Pause();
          break;

        case "버리기": //All Item
          if (SelectedItem.Count == 1)
            RemoveItem(1);
          else
          {
            var repeat = true;
            while (repeat)
            {
              var questionText = new CTexts();
              questionText = CTexts.Make($"{{선택된 아이템이 총 }} {{{SelectedItem.Count}개, {Colors.txtInfo}}} {{가 있습니다. 몇개를 버리시겠습니까?\n    0을 입력하면 취소됩니다.}}");
              SelectedItemCTexts();
              var answer = ReadIntScean(questionText, 0, SelectedItem.Count, false);

              if (answer == 0) repeat = false;
              else
              {
                repeat = false;
                RemoveItem(answer);
              }
            }
          }
          break;

        case "착용 하기": //Equipment Item

          break;

        case "사용 하기": //Consume Item
          // SelectedItem.UseItem();
          break;
      }
    }

    private void Lose(int count = 1)
    {
      MyInventory.RemoveItem(MyInvenInfo.ItemType, SelectedItemIndex, count);
    }

    private void RemoveItem(int count)
    {
      var questionText = new CTexts();
      var selectSceneItems = new SelectSceneItems();

      questionText = CTexts.Make($"{{선택된 아이템 }} {{{count}개, {Colors.txtInfo}}} {{ 를 버리시겠습니까?}}");
      selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make("{예}")));
      selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make("{아니요}")));
      SelectedItemCTexts();
      var answer = SelectScene(questionText, selectSceneItems, false);

      PrintText(SelectedItem.Name);
      if (answer == 1)
      {
        if (count == SelectedItem.Count)
        {
          PrintText(CTexts.Make($"{{을(를) 다 버렸습니다.}}"));
        }
        else
        {
          PrintText(CTexts.Make($"{{ {count}개, {Colors.txtInfo}}} {{를 버려서 현재 }} {{{SelectedItem.Count - count}개, {Colors.txtInfo}}} {{남았습니다.}}"));
        }

        Lose(count);
        PrintText("\n");
      }
      else
      {
        PrintText(CTexts.Make("{(을)를 버리지 않았습니다.}"));
      }
      Pause();
    }
  }
}
