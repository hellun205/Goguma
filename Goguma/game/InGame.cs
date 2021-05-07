using Goguma.Game.Console;
using Goguma.Game.Object.Inventory;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game
{
  static class InGame
  {

    public static void Go()
    {
      TestInventory();
    }

    public static void Test()
    {
      CTexts questionCText = CTexts.Make("{TEST QUESTION!, cyan}");
      SelectSceneItems selectSceneItems = new SelectSceneItems();

      selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make("{test1 Red, red}")));
      selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make("{test2 Blue, blue}")));
      selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make("{test3 Yellow, yellow}")));

      PrintText(SelectScene(questionCText, selectSceneItems).ToString());

      Pause();

      CTexts questionCText2 = CTexts.Make("{TEST QUESTION2! Write Any Text!, cyan}");

      PrintText(ReadTextScean(questionCText2));

      Pause();

    }

    public static void TestInventory()
    {
      Inventory myInventory = new Inventory();

      myInventory.EquipmentItems.Add(new Item()
      {
        Name = CTexts.Make("{테스트아이템1, yellow}{1}{2}{3}{4}{5}{6}")
      });

      myInventory.EquipmentItems.Add(new Item()
      {
        Name = CTexts.Make("{테스트아이템2, red}")
      });


      myInventory.PrintInventory(Object.Enum.ItemType.Equipment);
      Pause();

      myInventory.PrintInventory(Object.Enum.ItemType.Consume);
      Pause();

      myInventory.PrintInventory(Object.Enum.ItemType.Other);
      Pause();
    }


  }
}
