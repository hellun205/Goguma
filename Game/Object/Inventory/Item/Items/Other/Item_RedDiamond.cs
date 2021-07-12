using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Other;

namespace Goguma.Game.Object.Inventory.Item.Items
{
  [Serializable]
  public class Item_RedDiamond : OtherItem
  {
    public override ItemList Material => ItemList.RED_DIAMOND;

    public static readonly IItem Instance = new Item_RedDiamond();

    public override CTexts Name => CTexts.Make($"{{레드 다이아몬드,{Colors.txtDanger}}}");

    public override CTexts Descriptions => CTexts.Make("{매우 희귀한 보석이다. 다이아몬드 보다 더욱 비싸고 희귀하다.}}");

    public override int SalePrice => 375000;

    public override bool IsSalable => true;

    public override int PurchasePrice => (int)(SalePrice * 1.75);

    public override bool IsPurchasable => true;


    public Item_RedDiamond() : base() { }
  }
}