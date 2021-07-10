using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Other;

namespace Goguma.Game.Object.Inventory.Item.Items
{
  [Serializable]
  public class Item_GoldIngot : OtherItem
  {
    public override ItemList Material => ItemList.GOLD_INGOT;

    public override CTexts Name => CTexts.Make($"{{금괴,{Colors.txtWarning}}}");

    public override CTexts Descriptions => CTexts.Make("{말 그대로 금괴이다.}");

    public override int SalePrice => 10000;

    public override bool IsSalable => true;

    public override int PurchasePrice => (int)(SalePrice * 1.25);

    public override bool IsPurchasable => true;


    public Item_GoldIngot() : base() { }
  }
}