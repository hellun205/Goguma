using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item;
using System.Collections.Generic;
using static Goguma.Game.Console.ConsoleFunction;
using System;
using Goguma.Game.Object.Entity.Player;

namespace Goguma.Game.Object.Inventory
{
  [Serializable]
  class Inventory
  {
    public List<IItem> ConsumeItems { get; set; }
    public List<IItem> EquipmentItems { get; set; }
    public List<IItem> OtherItems { get; set; }

    public Equipment Equipment { get; set; }
    public IPlayer Player { get; set; }

    public Inventory(IPlayer player)
    {
      ConsumeItems = new List<IItem>();
      EquipmentItems = new List<IItem>();
      OtherItems = new List<IItem>();
      Equipment = new Equipment();
      Player = player;
    }

    public void PrintInventory()
    {
      var repeat = true;
      while (repeat)
      {
        var questionText = new CTexts();
        var selectSceneItems = new SelectSceneItems();

        questionText = CTexts.Make("{어떤 인벤토리를 열으시겠습니까?}");
        for (var i = 0; i < Enum.GetValues(typeof(ItemType)).Length; i++)
        {
          var invenInfo = new InvenInfo(this, (ItemType)i);
          selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make($"{{{invenInfo.TypeString} 아이템, {Colors.txtSuccess}}} {{ 인벤토리}}")));
        }
        selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make($"{{뒤로 가기, {Colors.txtMuted}}}")));
        var answer = SelectScene(questionText, selectSceneItems) - 1;

        if (selectSceneItems.Items[answer].Texts.ToString() == "뒤로 가기")
          repeat = false;
        else
          PrintInventory((ItemType)answer);
      }

    }
    public void PrintInventory(ItemType itemType)
    {
      var repeat = true;
      while (repeat)
      {
        var invenInfo = new InvenInfo(this, itemType);

        var questionText = new CTexts();
        var selectSceneItems = new SelectSceneItems();

        questionText = CTexts.Make($"{{인벤토리, {Colors.txtSuccess}}}{{ : }}{{{invenInfo.TypeString}, {Colors.txtSuccess}}}{{ 를 엽니다. }}{{\n    아이템, {Colors.txtInfo}}}{{를 선택하세요.}}");

        for (int i = 0; i < invenInfo.TypeItems.Count; i++)
          selectSceneItems.Items.Add(
            new SelectSceneItem(CTexts.Make($"{{{invenInfo.TypeItems[i].Name.ToString()}}} {{ [{invenInfo.TypeItems[i].Count}], {Colors.txtInfo}}}")));

        selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make($"{{뒤로 가기, {Colors.txtMuted}}}")));
        int answer = SelectScene(questionText, selectSceneItems) - 1;

        if (selectSceneItems.Items[answer].Texts.ToString() == "뒤로 가기")
          repeat = false;
        else
          SelectItem(itemType, answer);
      }
    }

    private void SelectItem(ItemType itemType, int index)
    {
      // bool repeat = true;
      // while (repeat)
      // {
      var invenInfo = new InvenInfo(this, itemType);
      var itemInfo = new ItemInfo(itemType);
      var selectedItem = invenInfo.TypeItems[index];

      var questionText = new CTexts();
      var selectSceneItems = new SelectSceneItems();

      questionText =
          CTexts.Make($"{{무슨 작업을 하시겠습니까?\n    }} {{\n    선택 : }} {{{selectedItem.Name.ToString()}}} {{ [{selectedItem.Count}], {Colors.txtInfo}}} {{\n    위치 : }} {{{invenInfo.TypeString},{Colors.txtSuccess}}} {{ . }} {{{index + 1},{Colors.txtSuccess}}}");

      for (int i = 0; i < itemInfo.SelectItemAnswers.Count; i++)
        selectSceneItems.Items.Add(new SelectSceneItem(itemInfo.SelectItemAnswers[i]));

      var answer = SelectScene(questionText, selectSceneItems) - 1;
      string answerText;

      answerText = selectSceneItems.Items[answer].Texts.ToString();

      if (selectSceneItems.Items[answer].Texts.ToString() != "뒤로 가기")
      {
        var itemOptionInfo = new ItemOptionInfo(this, itemType, index, answerText);
        itemOptionInfo.Act();
        Pause();
      }


      // }
    }

    public void RemoveItem(ItemType itemType, int index, int count)
    {
      var invenInfo = new InvenInfo(this, itemType);
      var selectedItem = invenInfo.TypeItems[index];

      if (count == selectedItem.Count)
        invenInfo.TypeItems.RemoveAt(index);
      else
        selectedItem.Count -= count;
    }
  }
}
