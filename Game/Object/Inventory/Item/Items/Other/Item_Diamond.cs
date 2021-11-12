using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Other;

namespace Goguma.Game.Object.Inventory.Item.Items
{
  [Serializable]
  public class ItemDiamond : OtherItem
  {
    public override ItemList Material => ItemList.DIAMOND;

    public static readonly IItem Instance = new ItemDiamond();

    public override CTexts Name => CTexts.Make($"{{다이아몬드,{Colors.txtInfo}}}");

    public override CTexts Descriptions => CTexts.Make("{매우 희귀한 보석이다.}}");

    public override int SalePrice => 75000;

    public override bool IsSalable => true;

    public override int PurchasePrice => (int)(SalePrice * 1.5);

    public override bool IsPurchasable => true;


    public ItemDiamond() : base() { }
  }
}