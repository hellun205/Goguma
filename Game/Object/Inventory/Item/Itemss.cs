using System;
using Goguma.Game.Object.Inventory.Item.Items;

namespace Goguma.Game.Object.Inventory.Item
{
  public static partial class Itemss
  {
    // public static IItem GetNew(ItemList item)
    // {
    //   switch (item)
    //   {
    //     case ItemList.TEST_ITEM1: return new Item_TestWep1();

    //     case ItemList.TEST_ITEM2: return new Item_TestHead1();

    //     case ItemList.STICKY_LIQUID: return new Item_StickyLiquid();

    //     case ItemList.GOBLINS_SWORD: return new Item_GoblinsSword();

    //     case ItemList.GOBLINS_ARMOR: return new Item_GoblinsArmor();

    //     case ItemList.GOLD_GOBLIN_COIN: return new Item_GoldGoblinCoin();

    //     case ItemList.GOLD_GOBLINS_SWORD: return new Item_GoldGoblinsSword();

    //     case ItemList.DIAMOND: return new Item_Diamond();

    //     case ItemList.RED_DIAMOND: return new Item_RedDiamond();

    //     case ItemList.EMERALD: return new Item_Emerald();

    //     case ItemList.GOLD_INGOT: return new Item_GoldIngot();

    //     case ItemList.POTION_1: return new Item_TestPotion();

    //     case ItemList.SKILLBOOK_TEST_SKILL1: return new Item_TestSkill1SB();

    //     case ItemList.SKILLBOOK_TEST_SKILL2: return new Item_TestSkill2SB();

    //     default: throw new NotImplementedException();
    //   }
    // }

    public static IItem GetInstance(ItemList item)
    {
      switch (item)
      {
        case ItemList.TestItem1: return ItemTestWep1.Instance;

        case ItemList.TestItem2: return ItemTestHead1.Instance;

        case ItemList.StickyLiquid: return ItemStickyLiquid.Instance;

        case ItemList.GoblinsSword: return ItemGoblinsSword.Instance;

        case ItemList.GoblinsArmor: return ItemGoblinsArmor.Instance;

        case ItemList.GoldGoblinCoin: return ItemGoldGoblinCoin.Instance;

        case ItemList.GoldGoblinsSword: return ItemGoldGoblinsSword.Instance;

        case ItemList.Diamond: return ItemDiamond.Instance;

        case ItemList.RedDiamond: return ItemRedDiamond.Instance;

        case ItemList.Emerald: return ItemEmerald.Instance;

        case ItemList.GoldIngot: return ItemGoldIngot.Instance;

        case ItemList.Potion1: return ItemTestPotion.Instance;

        case ItemList.SkillbookTestSkill1: return ItemTestSkill1Sb.Instance;

        case ItemList.SkillbookTestSkill2: return ItemTestSkill2Sb.Instance;

        case ItemList.Apple: return ItemApple.Instance;

        default: throw new NotImplementedException();
      }
    }
  }
}