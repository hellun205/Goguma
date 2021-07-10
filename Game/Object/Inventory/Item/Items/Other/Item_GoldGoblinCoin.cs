using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Other;

namespace Goguma.Game.Object.Inventory.Item.Items
{
  [Serializable]
  public class Item_GoldGoblinCoin : OtherItem
  {
    public override ItemList Material => ItemList.GOLD_GOBLIN_COIN;

    public override CTexts Name => CTexts.Make($"{{황금 고블린 코인, {Colors.txtWarning}}}");

    public override CTexts Descriptions => CTexts.Make("{헉! 황금 고블린을 잡으면 나오는 코인이다!}");

    public override int SalePrice => 5000;

    public override bool IsSalable => true;

    public Item_GoldGoblinCoin() : base() { }
  }
}