using Goguma.Game.Console;
using System;

using static Goguma.Game.Console.StringFunction;
using static Goguma.Game.Console.ConsoleFunction;
using Colorify;
using Microsoft.VisualBasic;

namespace Goguma.Game.Object.Inventory.Item
{
  [Serializable]
  class ItemOptionInfo
  {
    private Inventory MyInventory { get; set; }
    private InvenInfo MyInvenInfo { get; set; }
    // private ItemInfo MyItemInfo { get; set; }
    private int SelectedItemIndex { get; set; }
    private string OptionText { get; set; }

    private IItem SelectedItem { get; set; }

    public ItemOptionInfo(Inventory inventory, ItemType itemType, int selectedItemIndex, string optionText)
    {
      MyInventory = inventory;
      MyInvenInfo = new InvenInfo(inventory, itemType);
      // MyItemInfo = new ItemInfo(itemType);
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
          PrintInfo();
          break;
        case "버리기": //All Item
          Trash();
          break;
        case "착용 하기": //Equipment Item
          EquipItem();
          break;
        case "사용 하기": //Consume Item
          ConsumeItemUse();
          break;
      }
    }

    private void Lose(int count = 1)
    {
      MyInventory.RemoveItem(MyInvenInfo.ItemType, SelectedItemIndex, count);
    }

    private void Get(IItem item)
    {
      var invenInfo = new InvenInfo(MyInventory, item.Type);

      for (var i = 0; i < invenInfo.TypeItems.Count; i++)
      {
        if (invenInfo.TypeItems[i].Name.ToString() == item.Name.ToString()/* && item1.Lore == item.Lore && item1.Description == item.Description*/)
        {
          invenInfo.TypeItems[i].Count += item.Count;
          return;
        }
      }
      invenInfo.TypeItems.Add(item);
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
      PrintText(CTexts.Make($"{{ {MyInvenInfo.TypeString} 아이템\n  , {Colors.txtWarning}}}"));
      PrintText(CTexts.Make($"{{{SelectedItem.Lore}, {Colors.txtMuted}}}"));
      PrintText("\n");
      PrintText(SelectedItem.Description);
      PrintText("\n");

      SelectedItem.DescriptionItem();
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
        Pause();
        MyInventory.Player.PrintAbout();
      }
    }

    private void EquipItem()
    {
      var sItem = (EquipmentItem)SelectedItem;
      var eType = sItem.EquipmentType;
      var em = MyInventory.Equipment;
      sItem.DescriptionItemAP(MyInventory.Player);

      if (em.Items.GetItem(eType).IsAir)
      {
        if (ReadYesOrNoScean(CTexts.Make($"{{{em.Items.GetTypeString(eType)},{Colors.txtSuccess}}} {{에 }} {{{sItem.Name.ToString()}, {Colors.txtInfo}}} {{을(를) 착용하시겠습니까?}}")))
        {
          PrintText(CTexts.Make($"{{{em.Items.GetTypeString(eType)},{Colors.txtSuccess}}} {{에 }} "));
          PrintText(sItem.Name);
          PrintText("을(를) 착용하였습니다.");
          Lose();
          em.Items.SetItem(eType, sItem);
          Pause();
        }
      }
      else
      {
        if (em.Items.GetItem(eType).Name.ToString() == sItem.Name.ToString()/* && item1.Lore == item.Lore && item1.Description == item.Description*/)
        {
          PrintText(CTexts.Make($"{{{em.Items.GetTypeString(eType)},{Colors.txtSuccess}}} {{에 이미 }} "));
          PrintText(CTexts.Make($"{{{em.Items.GetItem(eType).Name}, {Colors.txtInfo}}} {{을(를) 착용하고 있습니다.}}"));
          return;
        }
        if (ReadYesOrNoScean(CTexts.Make($"{{{em.Items.GetTypeString(eType)},{Colors.txtSuccess}}} {{에 }} {{{em.Items.GetItem(eType).Name.ToString()}, {Colors.txtInfo}}} {{(이)가 이미 존재합니다. }} {{{sItem.Name.ToString()}, {Colors.txtInfo}}} {{을(를) 착용하시겠습니까?}}")))
        {
          PrintText(CTexts.Make($"{{{em.Items.GetTypeString(eType)},{Colors.txtSuccess}}} {{에 이미 착용하고 있는 }} "));
          PrintText(CTexts.Make($"{{{em.Items.GetItem(eType).Name}, {Colors.txtInfo}}}"));
          PrintText("을(를) 벗고, ");
          PrintText(CTexts.Make($"{{{sItem.Name}, {Colors.txtInfo}}}"));
          PrintText("을(를) 착용하였습니다.");
          Lose();
          Get(em.Items.GetItem(eType));
          em.Items.SetItem(eType, sItem);
          Pause();
        }
      }
    }
  }
}

