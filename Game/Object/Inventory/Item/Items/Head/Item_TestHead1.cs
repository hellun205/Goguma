using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Equipment;

namespace Goguma.Game.Object.Inventory.Item.Items
{
  [Serializable]
  public class ItemTestHead1 : EHead
  {
    public override ItemList Material => ItemList.TEST_ITEM2;

    public static readonly IItem Instance = new ItemTestHead1();

    public override CTexts Name => CTexts.Make("{테스트 모자 A}");

    public override CTexts Descriptions => CTexts.Make("{테스트용으로 사용되는 아이템이다.}");

    public override EquipEffect Effect => new()
    {
      MaxHp = 20,
      DefPer = 0.2
    };

    public ItemTestHead1() : base() { }
  }
}