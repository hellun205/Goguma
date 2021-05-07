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
        Name = CTexts.Make("{테스트아이템1, yellow}")
      });

      myInventory.EquipmentItems.Add(new Item()
      {
        Name = CTexts.Make("{테스트아이템2, red}")
      });

      myInventory.ConsumeItems.Add(new Item()
      {
        Name = CTexts.Make("{테스트 소비 아이템1, blue}")
      });

      myInventory.ConsumeItems.Add(new Item()
      {
        Name = CTexts.Make("{테스트포션1, red}")
      });

      myInventory.OtherItems.Add(new Item()
      {
        Name = CTexts.Make("{테스트 기타 아이템, cyan}")
      });
      myInventory.PrintInventory(Object.Enum.ItemType.Equipment);
    }
  }
}