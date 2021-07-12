using Goguma.Game.Console;
using System;
using static Goguma.Game.Console.ConsoleFunction;
using Colorify;
using Goguma.Game.Object.Inventory.Item.Consume;
using Goguma.Game.Object.Inventory.Item.Equipment;

namespace Goguma.Game.Object.Inventory.Item
{
  [Serializable]
  class ItemOption
  {
    private Inventory MyInventory { get; set; } // all
    private InvenType InvType { get; set; } // all
    private string OptionText { get; set; } // all
    private CTexts SText { get; set; } // all
    private ItemPair SelectedItem { get; set; } // all
    private WearingType WType { get; set; } // wearing
    public ItemOption(Inventory inventory, ItemPair item, string optionText) // Having Item
    {
      MyInventory = inventory;
      OptionText = optionText;
      SelectedItem = item;

      InvType = InvenType.Having;

      SText = CTexts.Make($"{{\n    선택 : }} ").Combine(SelectedItem.ItemM.DisplayName).Combine($"{{ [ {SelectedItem.Count}개 ], {Colors.txtInfo}}} {{\n    위치 : }} {{{InvenItems.GetTypeString(InvType)},{Colors.txtSuccess}}} {{.}} {{{Item.GetTypeString(SelectedItem.ItemM.Type)},{Colors.txtSuccess}}},{Colors.txtSuccess}}}");
    }

    public ItemOption(Inventory inventory, WearingType wType, string optionText) // Wearing Item
    {
      MyInventory = inventory;
      OptionText = optionText;
      SelectedItem = (ItemPair)inventory.Items.wearing[wType];
      WType = wType;

      InvType = InvenType.Wearing;

      SText = CTexts.Make($"{{\n    선택 : }} ").Combine(SelectedItem.ItemM.DisplayName).Combine($"{{ [ {SelectedItem.Count}개 ], {Colors.txtInfo}}} {{\n    위치 : }} {{{InvenItems.GetTypeString(InvType)},{Colors.txtSuccess}}} {{.}} {{{Item.GetTypeString(SelectedItem.ItemM.Type)},{Colors.txtSuccess}}},{Colors.txtSuccess}}}");
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
      switch (InvType)
      {
        case InvenType.Wearing:
          MyInventory.RemoveItem(WType);
          break;
        case InvenType.Having:
          MyInventory.RemoveItem(new ItemPair(SelectedItem.Item, count));
          break;
      }
    }

    private void Get(ItemPair item)
    {
      switch (InvType)
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
      var answer = ReadYesOrNo(CTexts.Make($"{{선택된 아이템 }} {{{count}개, {Colors.txtInfo}}} {{ 를 버리시겠습니까?\n}}").Combine(SText)/*.Combine(SelectedItem.Info())*/);

      PrintCText(SelectedItem.ItemM.Name);
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
          int count;
          if (ReadInt(CTexts.Make($"{{선택된 아이템이 총 }} {{{SelectedItem.Count}개, {Colors.txtInfo}}} {{가 있습니다. 몇개를 버리시겠습니까?\n}}").Combine(SText), out count, 0, 0, SelectedItem.Count)) return false;
          else
          {
            return RemoveItem(count);
          }
        }
      }
    }

    private bool PrintInfo()
    {
      SelectedItem.ItemM.Information();
      return false;
    }

    private bool ConsumeItemUse()
    {
      var sItem = (IConsumeItem)(SelectedItem.ItemM);
      if (ReadYesOrNo(sItem.Name.Combine("{을(를) 사용하시겠습니까?\n}").Combine(sItem.EffectInfo()).Combine("{\n}")))
      {
        PrintCText(sItem.Name.Combine("{(을)를 사용하였습니다.\n}"));
        Pause();
        PrintCText(sItem.UsedText());
        Pause();

        sItem.UseItem(MyInventory.Player);
        Lose(sItem.LoseCount);
        return true;
      }
      else return false;
    }

    private bool EquipItem()
    {
      var sItem = (EquipmentItem)SelectedItem.ItemM;
      var woreItemMaterial = MyInventory.Items.wearing[sItem.EType];
      // sItem.DescriptionItemAP(MyInventory.Player);

      if (woreItemMaterial == null)
      {
        if (ReadYesOrNo(CTexts.Make($"{{{sItem.ETypeString},{Colors.txtSuccess}}} {{에 }}").Combine(sItem.Name).Combine("{을(를) 착용하시겠습니까?\n}").Combine(sItem.EffectInfo())))
        {
          PrintCText(CTexts.Make($"{{{sItem.ETypeString},{Colors.txtSuccess}}} {{에 }} ").Combine(sItem.Name).Combine("{(을)를 착용하였습니다.}"));
          Pause();
          PrintCText(sItem.EquipedText());
          Pause();

          Lose();
          MyInventory.SetItem(sItem.EType, SelectedItem);
          return true;
        }
        else return false;
      }
      else
      {
        var woreItem = ((ItemPair)woreItemMaterial).ItemM;
        if (woreItem.Name.ToString() == sItem.Name.ToString()/* && item1.Lore == item.Lore && item1.Description == item.Description*/)
        {
          PrintCText(CTexts.Make($"{{{sItem.ETypeString},{Colors.txtSuccess}}} {{에 이미 }} ").Combine(woreItem.Name).Combine("{(을)를 착용하고 있습니다.}"));
          return false;
        }
        if (ReadYesOrNo(CTexts.Make($"{{{sItem.ETypeString},{Colors.txtSuccess}}} {{에 }}").Combine(woreItem.Name).Combine("{(이)가 이미 존재합니다. }").Combine(sItem.Name).Combine("{을(를) 착용하시겠습니까?\n}").Combine(sItem.EffectInfo())))
        {
          PrintCText(CTexts.Make($"{{{sItem.ETypeString},{Colors.txtSuccess}}} {{에 이미 착용하고 있는 }} ").Combine(woreItem.Name).Combine("{(을)를 벗고，}").Combine(sItem.Name).Combine("{(을)를 착용하였습니다.}"));
          Pause();
          PrintCText(sItem.EquipedText());
          Pause();

          Lose();
          Get(new ItemPair(woreItem.Material, 1));
          MyInventory.SetItem(sItem.EType, SelectedItem);
          return true;
        }
        else return false;
      }
    }
    private bool UnEquipItem()
    {
      var sItem = (EquipmentItem)SelectedItem.ItemM;
      var em = MyInventory.Items.wearing;
      // sItem.DescriptionItemAP(MyInventory.Player);

      if (ReadYesOrNo(sItem.Name.Combine("{의 착용을 해제 하시겠습니까?}")))
      {
        PrintCText(sItem.Name.Combine("{의 착용을 해제 하였습니다.}"));
        Pause();
        PrintCText(sItem.UnEquipedText());
        Pause();

        Lose();
        MyInventory.GetItem(new ItemPair(sItem.Material, 1));
        Pause();
        return true;
      }
      else return false;
    }
  }
}


