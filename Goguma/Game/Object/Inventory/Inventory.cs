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
      InvenInfo invenInfo = new InvenInfo(this, itemType);

      CTexts questionText = new CTexts();
      SelectSceneItems selectSceneItems = new SelectSceneItems();

      questionText = CTexts.Make($"{{인벤토리, cyan}}{{ : }}{{{invenInfo.TypeString}, green}}{{ 를 엽니다. }}{{\n    아이템, cyan}}{{를 선택하세요.}}");
      selectSceneItems = new SelectSceneItems();

      for (int i = 0; i < invenInfo.TypeItem.Count; i++)
      {
        CTexts answerText;

        answerText = invenInfo.TypeItem[i].Name;
        answerText.Combine(CTexts.Make($"{{ ( }} {{{invenInfo.TypeItem[i].Count}개, cyan}} {{ )}}"));

        selectSceneItems.Items.Add(new SelectSceneItem(answerText));
      }

      SelectItem(itemType, SelectScene(questionText, selectSceneItems) - 1);
    }

    public void SelectItem(ItemType itemType, int index)
    {

    }
  }
}
