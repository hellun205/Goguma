using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Equipment;

namespace Goguma.Game.Object.Inventory.Item.Items
{
  [Serializable]
  public class ItemTestWep1 : EWeapon
  {
    public override ItemList Material => ItemList.TEST_ITEM1;

    public static readonly IItem Instance = new ItemTestWep1();

    public override CTexts Name => CTexts.Make("{테스트 무기}");

    public override CTexts Descriptions => CTexts.Make("{테스트용으로 사용되는 아이템이다.}");

    public override WeaponEffect Effect => new()
    {
      PhysicalDamage = 1,
      CritDmg = 10,
      CritPer = 50,
      PhysicalPenetration = 0.5
    };

    public ItemTestWep1() : base() { }
  }
}