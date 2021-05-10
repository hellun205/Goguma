﻿using Goguma.Game.Console;
using System;
using static Goguma.Game.Console.ConsoleFunction;
using Colorify;

namespace Goguma.Game.Object.Inventory.Item
{
  [Serializable]
  class ItemOption
  {
    private Inventory MyInventory { get; set; } // all
    private InvenType IType { get; set; } // all
    private string OptionText { get; set; } // all
    private CTexts SText { get; set; } // all
    private IItem SelectedItem { get; set; } // all
    private HavingType HType { get; set; } // having
    private int SIIndex { get; set; } // having
    private WearingType WType { get; set; } // wearing

    public ItemOption(Inventory inventory, HavingType hType, int selectedItemIndex, string optionText, InvenType iType = InvenType.Having) // Having Item
    {
      MyInventory = inventory;
      IType = iType;
      SIIndex = selectedItemIndex;
      OptionText = optionText;
      HType = hType;

      SelectedItem = inventory.Items.having.GetItems(hType)[selectedItemIndex];
      SText = CTexts.Make($"{{\n    선택 : }} {{{SelectedItem.Name.ToString()}}} {{ [{SelectedItem.Count}], {Colors.txtInfo}}} {{\n    위치 : }} {{{InvenInfo.Inven.GetTypeString(iType)},{Colors.txtSuccess}}} {{.}} {{{InvenInfo.HavingInven.GetTypeString(hType)},{Colors.txtSuccess}}} {{.}} {{{SIIndex + 1},{Colors.txtSuccess}}}");
    }

    public ItemOption(Inventory inventory, WearingType wType, string optionText, InvenType iType = InvenType.Wearing) // Wearing Item
    {
      MyInventory = inventory;
      IType = iType;
      OptionText = optionText;
      WType = wType;

      SelectedItem = inventory.Items.wearing.GetItem(wType);
      SText = CTexts.Make($"{{\n    선택 : }} {{{SelectedItem.Name.ToString()}}} {{ [{SelectedItem.Count}], {Colors.txtInfo}}} {{\n    위치 : }} {{{InvenInfo.Inven.GetTypeString(iType)},{Colors.txtSuccess}}} {{.}} {{{InvenInfo.WearingInven.GetTypeString(wType)},{Colors.txtSuccess}}}");
    }

    public void SelectedItemCTexts()
    {
      PrintText(SText);
    }

    public void Act()
    {
      switch (OptionText)
      {
        case "아이템 정보 보기": //All Item
          PrintInfo();
          break;
        case "버리기": //All Item
          Trash();
          break;
        case "착용": //Equipment Item
          EquipItem();
          break;
        case "사용": //Consume Item
          ConsumeItemUse();
          break;
      }
    }

    private void Lose(int count = 1)
    {
      switch (IType)
      {
        case InvenType.Wearing:
          MyInventory.RemoveItem(WType, count);
          break;
        case InvenType.Having:
          MyInventory.RemoveItem(HType, SIIndex, count);
          break;
      }
    }

    private void Get(IItem item)
    {
      switch (IType)
      {
        case InvenType.Wearing:
          break;
        case InvenType.Having:
          MyInventory.GetItem(HType, item);
          break;
      }
    }

    private void RemoveItem(int count)
    {
      SelectedItemCTexts();
      var answer = ReadYesOrNoScean(CTexts.Make($"{{선택된 아이템 }} {{{count}개, {Colors.txtInfo}}} {{ 를 버리시겠습니까?}}"), false);

      PrintText(SelectedItem.Name);
      if (answer == true)
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

    private void Trash()
    {
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
    }

    private void PrintInfo()
    {
      PrintText(SelectedItem.Name);
      PrintText(CTexts.Make($"{{ [{SelectedItem.Count}],{Colors.txtInfo}}}"));
      PrintText(CTexts.Make($"{{ {InvenInfo.HavingInven.GetTypeString(HType)} 아이템\n  , {Colors.txtWarning}}}"));
      PrintText(CTexts.Make($"{{{SelectedItem.Lore}, {Colors.txtMuted}}}"));
      PrintText("\n");
      PrintText(SelectedItem.Description);
      PrintText("\n");

      SelectedItem.DescriptionItemAP(MyInventory.Player);
      Pause();
    }

    private void ConsumeItemUse()
    {
      var sItem = (ConsumeItem)SelectedItem;
      sItem.DescriptionItemAP(MyInventory.Player);
      if (ReadYesOrNoScean(CTexts.Make($"{{{sItem.Name.ToString()}, {Colors.txtInfo}}} {{을(를) 사용하시겠습니까?}}")))
      {
        sItem.UseItem(MyInventory.Player);
        Lose(sItem.LoseCount);
        PrintText(sItem.Name);
        PrintText("(을)를 사용하였습니다.");
        MyInventory.Player.PrintAbout();
      }
    }

    private void EquipItem()
    {
      var sItem = (EquipmentItem)SelectedItem;
      var wType = sItem.EquipmentType;
      var em = MyInventory.Items.wearing;
      // sItem.DescriptionItemAP(MyInventory.Player);

      if (em.GetItem(wType).IsAir)
      {
        if (ReadYesOrNoScean(CTexts.Make($"{{{InvenInfo.WearingInven.GetTypeString(wType)},{Colors.txtSuccess}}} {{에 }} {{{sItem.Name.ToString()}, {Colors.txtInfo}}} {{을(를) 착용하시겠습니까?}}")))
        {
          PrintText(CTexts.Make($"{{{InvenInfo.WearingInven.GetTypeString(wType)},{Colors.txtSuccess}}} {{에 }} "));
          PrintText(sItem.Name);
          PrintText("을(를) 착용하였습니다.");
          Lose();
          MyInventory.SetItem(wType, sItem);
          Pause();
        }
      }
      else
      {
        if (em.GetItem(wType).Name.ToString() == sItem.Name.ToString()/* && item1.Lore == item.Lore && item1.Description == item.Description*/)
        {
          PrintText(CTexts.Make($"{{{InvenInfo.WearingInven.GetTypeString(wType)},{Colors.txtSuccess}}} {{에 이미 }} "));
          PrintText(CTexts.Make($"{{{em.GetItem(wType).Name}, {Colors.txtInfo}}} {{을(를) 착용하고 있습니다.}}"));
          return;
        }
        if (ReadYesOrNoScean(CTexts.Make($"{{{InvenInfo.WearingInven.GetTypeString(wType)},{Colors.txtSuccess}}} {{에 }} {{{em.GetItem(wType).Name.ToString()}, {Colors.txtInfo}}} {{(이)가 이미 존재합니다. }} {{{sItem.Name.ToString()}, {Colors.txtInfo}}} {{을(를) 착용하시겠습니까?}}")))
        {
          PrintText(CTexts.Make($"{{{InvenInfo.WearingInven.GetTypeString(wType)},{Colors.txtSuccess}}} {{에 이미 착용하고 있는 }} "));
          PrintText(CTexts.Make($"{{{em.GetItem(wType).Name}, {Colors.txtInfo}}}"));
          PrintText("을(를) 벗고, ");
          PrintText(CTexts.Make($"{{{sItem.Name}, {Colors.txtInfo}}}"));
          PrintText("을(를) 착용하였습니다.");
          Lose();
          Get(em.GetItem(wType));
          MyInventory.SetItem(wType, sItem);
          // Pause();
        }
      }
    }
  }
}
