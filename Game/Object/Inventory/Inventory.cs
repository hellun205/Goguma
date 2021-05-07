using Goguma.Game.Console;
using Goguma.Game.Object.Enum;
using Goguma.Game.Object.Interface;
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

      var invenInfo = new InvenInfo(this, itemType);

      var questionText = new CTexts();
      var selectSceneItems = new SelectSceneItems();

      questionText = CTexts.Make($"{{인벤토리, cyan}}{{ : }}{{{invenInfo.TypeString}, green}}{{ 를 엽니다. }}{{\n    아이템, cyan}}{{를 선택하세요.}}");
      selectSceneItems = new SelectSceneItems();

      for (int i = 0; i < invenInfo.TypeItems.Count; i++)
        selectSceneItems.Items.Add(
          new SelectSceneItem(invenInfo.TypeItems[i].Name.Combine(CTexts.Make($"{{ ( }} {{{invenInfo.TypeItems[i].Count}개, cyan}} {{ )}}"))));

      selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make("{뒤로 가기, Gray}")));

      while (repeat)
      {
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
      while (repeat)
      {
        var invenInfo = new InvenInfo(this, itemType);
        var itemInfo = new ItemInfo(itemType);

        var questionText = new CTexts();
        var selectSceneItems = new SelectSceneItems();

        questionText = CTexts.Make(
          $"{{무슨 작업을 하시겠습니까?\n    }} {{선택된 아이템 : , gray}}").Combine(invenInfo.TypeItems[index].Name).Combine(CTexts.Make($" {{ ( }} {{{invenInfo.TypeString},green}} {{ : }} {{{index + 1},green}} {{ )}}"));

        for (int i = 0; i < itemInfo.SelectItemAnswers.Count; i++)
          selectSceneItems.Items.Add(new SelectSceneItem(itemInfo.SelectItemAnswers[i]));

        //selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make("{뒤로 가기, Gray}")));

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
