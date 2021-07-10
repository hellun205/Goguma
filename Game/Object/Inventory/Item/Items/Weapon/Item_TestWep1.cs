using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Equipment;

namespace Goguma.Game.Object.Inventory.Item.Items
{
  [Serializable]
  public class Item_TestWep1 : EWeapon
  {
    public override ItemList Material => ItemList.TEST_ITEM1;

    public override CTexts Name => CTexts.Make("{테스트 무기}");

    public override CTexts Descriptions => CTexts.Make("{테스트용으로 사용되는 아이템이다.}");

    public override WeaponEffect Effect => new()
    {
      AttDmg = 1,
      CritDmg = 10,
      CritPer = 50,
      IgnoreDef = 0.5
    };

    public Item_TestWep1() : base() { }
  }
}