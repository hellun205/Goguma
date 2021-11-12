using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Other;

namespace Goguma.Game.Object.Inventory.Item.Items
{
  [Serializable]
  public class ItemStickyLiquid : OtherItem
  {
    public override ItemList Material => ItemList.STICKY_LIQUID;

    public static readonly IItem Instance = new ItemStickyLiquid();

    public override CTexts Name => CTexts.Make("{끈적끈적한 액체}");

    public override CTexts Descriptions => CTexts.Make("{만지기 싫은 아이템이다. 주로 슬라임을 처치하면 획득할 수 있다.}");

    public override int SalePrice => 3;

    public override bool IsSalable => true;

    public ItemStickyLiquid() : base() { }
  }
}