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
        Description = CTexts.Make("{착용하면 아무런 효과도 얻을 수 없다.}"),
        Count = 1
      });

      myInventory.EquipmentItems.Add(new EquipmentItem()
      {
        Name = CTexts.Make("{테스트아이템2}"),
        Lore = CTexts.Make("{테스트용으로 만들어진 아이템이다. 번호는 2이다., text-muted}"),
        Type = ItemType.Equipment,
        Description = CTexts.Make("{착용하면 여러가지 효과를 얻을 수 있다.}"),
        Increase = new ItemIncrease() { MaxHp = 500, MaxEp = 20, AttDmg = -5, DefPer = 1 },
        Count = 5
      });

      myInventory.ConsumeItems.Add(new ConsumeItem()
      {
        Name = CTexts.Make("{테스트 소비 아이템1}"),
        Lore = CTexts.Make("{테스트용으로 만들어진 아이템이다. C2,text-muted}"),
        Description = CTexts.Make("{사용하면 여러가지 효과를 볼 수 있다.}"),
        Type = ItemType.Consume,
        Effect = new ItemEffect() { Hp = 10, Ep = -10, AttDmg = 5, DefPer = 2, Exp = 4040, Gold = -10 },
        Count = 2
      });

      myInventory.ConsumeItems.Add(new ConsumeItem()
      {
        Name = CTexts.Make("{테스트포션1}"),
        Lore = CTexts.Make("{테스트용으로 만들어진 포션이다. C1,text-muted}"),
        Description = CTexts.Make("{사용하면 Hp를 회복하는 효과를 볼 수 있다.}"),
        Effect = new ItemEffect() { Hp = 500 },
        Type = ItemType.Consume,
        Count = 1
      });

      myInventory.OtherItems.Add(new Item()
      {
        Name = CTexts.Make("{테스트 기타 아이템}"),
        Type = ItemType.Other,
        Lore = CTexts.Make("{테스트용으로 만들어진 기타아이템이다. C1,text-muted}"),
        Description = CTexts.Make("{그냥 아이템이다. 이걸로 아무것도 할 수 있는 것은 없다.}"),
        Count = 10
      });
      myInventory.PrintInventory();
    }
  }
}