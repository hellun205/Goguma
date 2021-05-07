using Goguma.Game.Console;
using Goguma.Game.Object.Inventory;

namespace Goguma.Game
{
  static class InGame
  {
    public static void Go()
    {
      TestInventory();
    }


    public static void TestInventory()
    {
      Inventory myInventory = new Inventory();

      myInventory.EquipmentItems.Add(new Item()
      {
        Name = CTexts.Make("{테스트아이템1}")
      });

      myInventory.EquipmentItems.Add(new Item()
      {
        Name = CTexts.Make("{테스트아이템2}")
      });

      myInventory.ConsumeItems.Add(new Item()
      {
        Name = CTexts.Make("{테스트 소비 아이템1}")
      });

      myInventory.ConsumeItems.Add(new Item()
      {
        Name = CTexts.Make("{테스트포션1}")
      });

      myInventory.OtherItems.Add(new Item()
      {
        Name = CTexts.Make("{테스트 기타 아이템}")
      });
      myInventory.PrintInventory(Object.Enum.ItemType.Equipment);
    }
  }
}