using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Consume;
using Goguma.Game.Object.Inventory.Item.Equipment;
using Goguma.Game.Object.Inventory.Item.Other;
using Goguma.Game.Object.Skill;

namespace Goguma.Game.Object.Inventory.Item
{
  static class Items
  {
    static public IItem Get(ItemList item)
    {
      IItem resultItem;
      switch (item)
      {
        case ItemList.TEST_ITEM1:
          resultItem = new EWeapon()
          {
            Name = CTexts.Make("{테스트 무기}"),
            Descriptions = CTexts.Make("{테스트용으로 사용되는 아이템이다.}"),
            Effect = new WeaponEffect()
            {
              AttDmg = 1,
              CritDmg = 10,
              CritPer = 50,
              IgnoreDef = 0.5
            }
          };
          return resultItem;
        case ItemList.TEST_ITEM2:
          resultItem = new EHead()
          {
            Name = CTexts.Make("{테스트용 모자 B}"),
            Descriptions = CTexts.Make("{테스트용으로 사용되는 아이템이다.}"),
            Effect = new EquipEffect()
            {
              MaxHp = 20,
              DefPer = 0.2,
            }
          };
          return resultItem;
        case ItemList.STICKY_LIQUID:
          resultItem = new OtherItem()
          {
            Name = CTexts.Make("{끈적끈적한 액체}"),
            Descriptions = CTexts.Make("{만지기 싫은 아이템이다. 주로 슬라임을 잡으면 드랍한다.}"),
            SalePrice = 3,
            IsSalable = true,
            PurchasePrice = 6
          };
          return resultItem;
        case ItemList.GOBLINS_SWORD:
          resultItem = new EWeapon()
          {
            Name = CTexts.Make($"{{고블린,{Colors.txtInfo}}}{{의 검}}"),
            Descriptions = CTexts.Make($"{{고블린,{Colors.txtInfo}}}{{들이 주로 사용하는 검이다.}}"),
            SalePrice = 7,
            IsSalable = true,
            Effect = new WeaponEffect()
            {
              AttDmg = 3
            }
          };
          return resultItem;
        case ItemList.GOBLINS_ARMOR:
          resultItem = new EChestplate()
          {
            Name = CTexts.Make($"{{고블린,{Colors.txtInfo}}}{{의 갑옷}}"),
            Descriptions = CTexts.Make($"{{고블린,{Colors.txtInfo}}}{{들이 주로 착용하는 갑옷이다.}}"),
            SalePrice = 5,
            IsSalable = true,
            Effect = new EquipEffect()
            {
              MaxHp = 5,
              DefPer = 0.5
            }
          };
          return resultItem;
        case ItemList.GOLD_GOBLIN_COIN:
          resultItem = new OtherItem()
          {
            Name = CTexts.Make($"{{황금 고블린 코인,{Colors.txtWarning}}}"),
            Descriptions = CTexts.Make("{헉! 황금 고블린을 잡으면 나오는 코인이다.}"),
            SalePrice = 5000,
            IsSalable = true,
          };
          return resultItem;
        case ItemList.GOLD_GOBLINS_SWORD:
          resultItem = new EWeapon()
          {
            Name = CTexts.Make("{황금 고블린의 검}"),
            Descriptions = CTexts.Make("{황금 고블린들이 사용하는 검이다.}"),
            SalePrice = 1500,
            IsSalable = true,
            Effect = new WeaponEffect()
            {
              AttDmg = 9,
              CritDmg = 10,
              CritPer = 10
            }
          };
          return resultItem;
        case ItemList.DIAMOND:
          resultItem = new OtherItem()
          {
            Name = CTexts.Make($"{{다이아몬드,{Colors.txtInfo}}}"),
            Descriptions = CTexts.Make("{보석이다. 매우 희귀하다.}}"),
            SalePrice = 75000,
            PurchasePrice = 100000,
            IsSalable = true,
            IsPurchasable = true
          };
          return resultItem;
        case ItemList.RED_DIAMOND:
          resultItem = new OtherItem()
          {
            Name = CTexts.Make($"{{레드 다이아몬드,{Colors.txtInfo}}}"),
            Descriptions = CTexts.Make("{보석이다. 다이아몬드보다 비싸고 희귀하다.}}"),
            SalePrice = 375000,
            PurchasePrice = 500000,
            IsSalable = true,
            IsPurchasable = true
          };
          return resultItem;
        case ItemList.EMERALD:
          resultItem = new OtherItem()
          {
            Name = CTexts.Make($"{{에메랄드,{Colors.txtInfo}}}"),
            Descriptions = CTexts.Make("{보석이다.}"),
            SalePrice = 50000,
            PurchasePrice = 75000,
            IsSalable = true,
            IsPurchasable = true
          };
          return resultItem;
        case ItemList.GOLD_INGOT:
          resultItem = new OtherItem()
          {
            Name = CTexts.Make($"{{금괴}},{Colors.txtInfo}}}"),
            Descriptions = CTexts.Make("{말 그대로 금괴.}"),
            SalePrice = 10000,
            PurchasePrice = 12500,
            IsSalable = true,
            IsPurchasable = true
          };
          return resultItem;
        case ItemList.POTION_1:
          resultItem = new CPotion()
          {
            Name = CTexts.Make($"{{포션1}},{Colors.txtInfo}}}"),
            Descriptions = CTexts.Make("{체력을 회복시켜준다.}"),
            Effect = new PotionEffect()
            {
              HealHp = 10
            },
            SalePrice = 10,
            PurchasePrice = 15,
            IsSalable = true,
            IsPurchasable = true
          };
          return resultItem;
        case ItemList.SKILLBOOK_TEST_SKILL1:
          resultItem = new CSkillBook()
          {
            Name = CTexts.Make($"{{스킬 북: 테스트 스킬1}},{Colors.txtInfo}}}"),
            SkillToReceive = Skills.GetPlayerSkill(SkillList.TestSkill1),
            SalePrice = 100,
            PurchasePrice = 150,
            IsSalable = true,
            IsPurchasable = true
          };
          return resultItem;
        case ItemList.SKILLBOOK_TEST_SKILL2:
          resultItem = new CSkillBook()
          {
            Name = CTexts.Make($"{{스킬 북: 테스트 스킬2}},{Colors.txtInfo}}}"),
            SkillToReceive = Skills.GetPlayerSkill(SkillList.TestSkill2),
            SalePrice = 100,
            PurchasePrice = 150,
            IsSalable = true,
            IsPurchasable = true
          };
          return resultItem;
        default:
          return null;
      }
    }
  }
}