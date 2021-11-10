using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Other;

namespace Goguma.Game.Object.Inventory.Item.Items
{
  [Serializable]
  public class ItemRedDiamond : OtherItem
  {
    public override ItemList Material => ItemList.RedDiamond;

    public static readonly IItem Instance = new ItemRedDiamond();

    public override CTexts Name => CTexts.Make($"{{레드 다이아몬드,{Colors.txtDanger}}}");

    public override CTexts Descriptions => CTexts.Make("{매우 희귀한 보석이다. 다이아몬드 보다 더욱 비싸고 희귀하다.}}");

    public override int SalePrice => 375000;

    public override bool IsSalable => true;

    public override int PurchasePrice => (int)(SalePrice * 1.75);

    public override bool IsPurchasable => true;


    public ItemRedDiamond() : base() { }
  }
}