using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Other;

namespace Goguma.Game.Object.Inventory.Item.Items
{
  [Serializable]
  public class Item_Emerald : OtherItem
  {
    public override ItemList Material => ItemList.EMERALD;

    public override CTexts Name => CTexts.Make($"{{에메랄드,{Colors.txtInfo}}}");

    public override CTexts Descriptions => CTexts.Make("{보석이다.}}");

    public override int SalePrice => 50000;

    public override bool IsSalable => true;

    public override int PurchasePrice => (int)(SalePrice * 1.5);

    public override bool IsPurchasable => true;


    public Item_Emerald() : base() { }
  }
}