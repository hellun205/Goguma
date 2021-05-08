﻿using Goguma.Game.Console;
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

    public CTexts SelectedItemCTexts(CTexts message)
    {
      var cTexts = new CTexts();
      cTexts = message;
      cTexts = cTexts.Combine(CTexts.Make($"{{\n    선택 : }} {{{SelectedItem.Name.ToString()}}} {{ [{SelectedItem.Count}], {Colors.txtInfo}}} {{\n    위치 : }} {{{MyInvenInfo.TypeString},{Colors.txtSuccess}}} {{ . }} {{{SelectedItem.Count + 1},{Colors.txtSuccess}}}"));
      return cTexts;
    }

    public void Act()
    {
      switch (OptionText)
      {
        case "아이템 정보 보기": //All Item
          PrintText(SelectedItem.Name);
          PrintText(CTexts.Make($"{{ [{SelectedItem.Count}],{Colors.txtInfo}}}"));
          PrintText(CTexts.Make($"{{ {MyInvenInfo.TypeString} 아이템\n  , {Colors.txtWarning}}}"));
          PrintText(SelectedItem.Lore);
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
              questionText = SelectedItemCTexts(CTexts.Make($"{{선택된 아이템이 총 }} {{{SelectedItem.Count}개, {Colors.txtSuccess}}} {{가 있습니다. 몇개를 버리시겠습니까?\n    0을 입력하면 취소됩니다.}}"));
              var answer = ReadIntScean(questionText, 0, SelectedItem.Count);

              if (answer == 0) repeat = false;
              else
              {
                repeat = false;
                RemoveItem(answer);
              }
            }
          }
          break;
      }
    }

    private void Consume()
    {
      // TODO
    }

    private void RemoveItem(int count)
    {
      var questionText = new CTexts();
      var selectSceneItems = new SelectSceneItems();

      questionText = SelectedItemCTexts(CTexts.Make("{선택된 아이템을 버리시겠습니까?}"));
      selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make("{예}")));
      selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make("{아니요}")));
      var answer = SelectScene(questionText, selectSceneItems);
      SelectedItem.RemoveItem(count);

      if (answer == 1)
      {
        PrintText("\n");
        PrintText(SelectedItem.Name);
        PrintText(CTexts.Make($"{{ {count}개, {Colors.txtSuccess}}} {{를 버렸습니다.}}"));
        Pause();
      }

    }
  }
}