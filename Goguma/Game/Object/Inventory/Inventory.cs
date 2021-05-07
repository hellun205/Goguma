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

      questionText = CTexts.Make($"{{인벤토리, cyan}}{{ : }}{{{invenInfo.TypeString}, green}}{{ 를 엽니다. 아이템을 선택 하시오 }}");
      selectSceneItems = new SelectSceneItems();

      for (int i = 0; i < invenInfo.TypeItem.Count; i++)
      {
        selectSceneItems.Items.Add(new SelectSceneItem(invenInfo.TypeItem[i].Name));
      }

      SelectItem(itemType, SelectScene(questionText, selectSceneItems) - 1);

      //switch (itemType)
      //{
      //  case ItemType.Equipment:
      //    questionText = CTexts.Make("{인벤토리, cyan}{ : }{장비, green}{ 를 엽니다. }{\n  아이템, cyan}{을 선택하시오.}");
      //    selectSceneItems = new SelectSceneItems();

      //    for (int i = 0; i < EquipmentItems.Count; i++)
      //    {
      //      selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make($"{{{EquipmentItems[i].Name}}}")));
      //    }

      //    SelectItem(itemType, SelectScene(questionText, selectSceneItems) - 1);
      //    break;

      //  case ItemType.Consume:
      //    questionText = CTexts.Make("{인벤토리, cyan}{ : }{소비, green}{ 를 엽니다. }{\n  아이템, cyan}{을 선택하시오.}");
      //    selectSceneItems = new SelectSceneItems();

      //    for (int i = 0; i < ConsumeItems.Count; i++)
      //    {
      //      selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make($"{{{ConsumeItems[i].Name}}}")));
      //    }

      //    SelectItem(itemType, SelectScene(questionText, selectSceneItems) - 1);
      //    break;

      //  case ItemType.Other:
      //    questionText = CTexts.Make("{인벤토리, cyan}{ : }{기타, green}{ 를 엽니다. }{\n  아이템, cyan}{을 선택하시오.}");
      //    selectSceneItems = new SelectSceneItems();

      //    for (int i = 0; i < OtherItems.Count; i++)
      //    {
      //      selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make($"{{{OtherItems[i].Name}}}")));
      //    }

      //    SelectItem(itemType, SelectScene(questionText, selectSceneItems) - 1);
      //    break;
      //}
    }

    public void SelectItem(ItemType itemType, int index)
    {

    }
  }
}
