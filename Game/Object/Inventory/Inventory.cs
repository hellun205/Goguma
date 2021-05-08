using Colorify;
using Colorify.UI;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Entity.Player;
using System.Collections.Generic;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game.Object.Inventory
{
  class Inventory
  {
    public List<IItem> ConsumeItems { get; set; }
    public List<IItem> EquipmentItems { get; set; }
    public List<IItem> OtherItems { get; set; }

    public Equipment Equipment { get; set; }

    public Inventory()
    {
      ConsumeItems = new List<IItem>();
      EquipmentItems = new List<IItem>();
      OtherItems = new List<IItem>();
      Equipment = new Equipment();
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
        selectSceneItems = new SelectSceneItems();

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
      bool repeat = true;
      var invenInfo = new InvenInfo(this, itemType);
        var itemInfo = new ItemInfo(itemType);

        var questionText = new CTexts();
        var selectSceneItems = new SelectSceneItems();

          questionText = 
              CTexts.Make($"{{무슨 작업을 하시겠습니까?\n    }} {{\n    선택 : }} {{{invenInfo.TypeItems[index].Name.ToString()}}} {{ [{invenInfo.TypeItems[index].Count}], {Colors.txtInfo}}} {{\n    위치 : }} {{{invenInfo.TypeString},{Colors.txtSuccess}}} {{ . }} {{{index + 1},{Colors.txtSuccess}}}");

        for (int i = 0; i < itemInfo.SelectItemAnswers.Count; i++)
          selectSceneItems.Items.Add(new SelectSceneItem(itemInfo.SelectItemAnswers[i]));

      while (repeat)
      {
        var answer = SelectScene(questionText, selectSceneItems) - 1;
        string answerText;

        answerText = selectSceneItems.Items[answer].Texts.ToString();

        if (selectSceneItems.Items[answer].Texts.ToString() == "뒤로 가기")
          repeat = false;
        else
          ChooseSelectedItemOption(itemType, index, answerText);
      }
    }

    private void ChooseSelectedItemOption(ItemType itemType, int selectedItemIndex, string chooseOptionText)
    {
      var itemOptionInfo = new ItemOptionInfo(this, itemType, selectedItemIndex, chooseOptionText);
      itemOptionInfo.Act();
    }
  }
}
