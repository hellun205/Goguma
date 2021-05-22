﻿using Goguma.Game.Console;
using System;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;
using Colorify;
using Goguma.Game.Object.Inventory.Item.Consume;
using Goguma.Game.Object.Inventory.Item.Equipment;

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
      PrintCText(SText);
    }

    public bool Act()
    {
      switch (OptionText)
      {
        case "아이템 정보 보기": //All Item
          return PrintInfo();
        case "버리기": //All Item
          return Trash();
        case "착용": //Equipment Item
          return EquipItem();
        case "착용 해제":
          return UnEquipItem();
        case "사용": //Consume Item
          return ConsumeItemUse();
        default:
          return false;
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
          MyInventory.GetItem(item);
          break;
      }
    }

    private bool RemoveItem(int count)
    {
      SelectedItemCTexts();
      var answer = ReadYesOrNo(CTexts.Make($"{{선택된 아이템 }} {{{count}개, {Colors.txtInfo}}} {{ 를 버리시겠습니까?}}"));

      PrintCText(SelectedItem.Name);
      if (answer == true)
      {
        if (count == SelectedItem.Count)
          PrintCText($"{{을(를) 다 버렸습니다.}}");
        else
          PrintCText($"{{ {count}개, {Colors.txtInfo}}} {{를 버려서 현재 }} {{{SelectedItem.Count - count}개, {Colors.txtInfo}}} {{남았습니다.}}");
        Lose(count);
        PrintText("\n");
        Pause();
        return true;
      }
      else
      {
        PrintCText("{(을)를 버리지 않았습니다.}");
        Pause();
        return false;
      }
    }

    private bool Trash()
    {
      if (SelectedItem.Count == 1)
        return RemoveItem(1);
      else
      {
        while (true)
        {
          SelectedItemCTexts();
          int count;
          if (ReadInt($"{{선택된 아이템이 총 }} {{{SelectedItem.Count}개, {Colors.txtInfo}}} {{가 있습니다. 몇개를 버리시겠습니까?}}", out count, 0, 0, SelectedItem.Count)) return false;
          else
          {
            return RemoveItem(count);
          }
        }
      }
    }

    private bool PrintInfo()
    {
      SelectedItem.Information();
      return false;
    }

    private bool ConsumeItemUse()
    {
      var sItem = (IConsumeItem)SelectedItem;
      sItem.DescriptionItem();
      if (ReadYesOrNo(CTexts.Make($"{{{sItem.Name.ToString()}, {Colors.txtInfo}}} {{을(를) 사용하시겠습니까?}}")))
      {
        sItem.UseItem(MyInventory.Player);
        Lose(sItem.LoseCount);
        PrintCText(sItem.Name);
        PrintText("(을)를 사용하였습니다.");
        MyInventory.Player.Information();
        return true;
      }
      else return false;
    }

    private bool EquipItem()
    {
      var sItem = (EquipmentItem)SelectedItem;
      var wType = sItem.EquipmentType;
      var em = MyInventory.Items.wearing;
      // sItem.DescriptionItemAP(MyInventory.Player);

      if (em.GetItem(wType).IsAir)
      {
        if (ReadYesOrNo(CTexts.Make($"{{{InvenInfo.WearingInven.GetTypeString(wType)},{Colors.txtSuccess}}} {{에 }} {{{sItem.Name.ToString()}, {Colors.txtInfo}}} {{을(를) 착용하시겠습니까?}}")))
        {
          PrintCText($"{{{InvenInfo.WearingInven.GetTypeString(wType)},{Colors.txtSuccess}}} {{에 }} ");
          PrintCText(sItem.Name);
          PrintText("을(를) 착용하였습니다.");
          Lose();
          MyInventory.SetItem(wType, sItem);
          Pause();
          return true;
        }
        else return false;
      }
      else
      {
        if (em.GetItem(wType).Name.ToString() == sItem.Name.ToString()/* && item1.Lore == item.Lore && item1.Description == item.Description*/)
        {
          PrintCText($"{{{InvenInfo.WearingInven.GetTypeString(wType)},{Colors.txtSuccess}}} {{에 이미 }} ");
          PrintCText($"{{{em.GetItem(wType).Name}, {Colors.txtInfo}}} {{을(를) 착용하고 있습니다.}}");
          return false;
        }
        if (ReadYesOrNo(CTexts.Make($"{{{InvenInfo.WearingInven.GetTypeString(wType)},{Colors.txtSuccess}}} {{에 }} {{{em.GetItem(wType).Name.ToString()}, {Colors.txtInfo}}} {{(이)가 이미 존재합니다. }} {{{sItem.Name.ToString()}, {Colors.txtInfo}}} {{을(를) 착용하시겠습니까?}}")))
        {
          PrintCText($"{{{InvenInfo.WearingInven.GetTypeString(wType)},{Colors.txtSuccess}}} {{에 이미 착용하고 있는 }} ");
          PrintCText($"{{{em.GetItem(wType).Name}, {Colors.txtInfo}}}");
          PrintText("을(를) 벗고, ");
          PrintCText($"{{{sItem.Name}, {Colors.txtInfo}}}");
          PrintText("을(를) 착용하였습니다.");
          Lose();
          Get(em.GetItem(wType));
          MyInventory.SetItem(wType, sItem);
          return true;
        }
        else return false;
      }
    }
    private bool UnEquipItem()
    {
      var sItem = (EquipmentItem)SelectedItem;
      var hType = sItem.Type;
      var em = MyInventory.Items.wearing;
      // sItem.DescriptionItemAP(MyInventory.Player);

      if (ReadYesOrNo(CTexts.Make($"{{{sItem.Name.ToString()}, {Colors.txtInfo}}} {{의 착용을 해제 하시겠습니까?}}")))
      {
        PrintCText(sItem.Name);
        PrintText("의 착용을 해제 하였습니다.");
        Lose();
        MyInventory.GetItem(sItem);
        Pause();
        return true;
      }
      else return false;
    }
  }
}


