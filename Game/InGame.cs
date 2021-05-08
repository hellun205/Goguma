using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory;
using static Goguma.Game.Console.ConsoleFunction;
using Goguma.Game.Object.Inventory.Item;

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

      myInventory.EquipmentItems.Add(new EquipmentItem()
      {
        Name = CTexts.Make("{테스트아이템1}"),
        Lore = CTexts.Make("{테스트용으로 만들어진 아이템이다. 번호는 1이다., text-muted}"),
        Type = ItemType.Equipment,
        Description = CTexts.Make("{  착용하면 아무런 효과도 얻을 수 없다.}")
      });

      myInventory.EquipmentItems.Add(new EquipmentItem()
      {
        Name = CTexts.Make("{테스트아이템2}")
      });

      myInventory.ConsumeItems.Add(new ConsumeItem()
      {
        Name = CTexts.Make("{테스트 소비 아이템1}"),
        Lore = CTexts.Make("{테스트용으로 만들어진 아이템이다. C2,text-muted}"),
        Description = CTexts.Make("{사용하면 Hp를 회복하는 효과를 볼 수 있다.}"),
        Effect = new ItemEffect()
        {
          Hp = 10, Ep = -10, AttDmg = 5, DefPer = 2, Exp = 4040, Gold = -10
        }
      });

      myInventory.ConsumeItems.Add(new ConsumeItem()
      {
        Name = CTexts.Make("{테스트포션1}")
      });

      myInventory.OtherItems.Add(new Item()
      {
        Name = CTexts.Make("{테스트 기타 아이템}")
      });
      myInventory.PrintInventory(ItemType.Equipment);
      myInventory.PrintInventory(ItemType.Consume);
      myInventory.PrintInventory(ItemType.Other);
    }
  }
}