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

      for (int i = 0; i < invenInfo.TypeItems.Count; i++)
      {
        selectSceneItems.Items.Add(
          new SelectSceneItem(invenInfo.TypeItems[i].Name.Combine(CTexts.Make($"{{ ( }} {{{invenInfo.TypeItems[i].Count}개, cyan}} {{ )}}"))));
      }

      SelectItem(itemType, SelectScene(questionText, selectSceneItems) - 1);
    }

    public void SelectItem(ItemType itemType, int index)
    {
      InvenInfo invenInfo = new InvenInfo(this, itemType);
      ItemInfo itemInfo = new ItemInfo( itemType);

      CTexts questionText = new CTexts();
      SelectSceneItems selectSceneItems = new SelectSceneItems();

      questionText = CTexts.Make(
        $"{{무슨 작업을 하시겠습니까?\n    }} {{선택된 아이템 : , gray}}").Combine(invenInfo.TypeItems[index].Name).Combine(CTexts.Make(" {{ ( }} {{{invenInfo.TypeString},green}} {{ : }} {{{index},green}} {{ )}}"));

      for (int i = 0; i < itemInfo.SelectItemAnswers.Count; i++)
        selectSceneItems.Items.Add(new SelectSceneItem(itemInfo.SelectItemAnswers[i]));

      SelectScene(questionText, selectSceneItems);
    }
  }
}
