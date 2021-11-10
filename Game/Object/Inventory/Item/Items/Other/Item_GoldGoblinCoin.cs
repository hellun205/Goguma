using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Other;

namespace Goguma.Game.Object.Inventory.Item.Items
{
  [Serializable]
  public class ItemGoldGoblinCoin : OtherItem
  {
    public override ItemList Material => ItemList.GoldGoblinCoin;

    public static readonly IItem Instance = new ItemGoldGoblinCoin();

    public override CTexts Name => CTexts.Make($"{{황금 고블린 코인, {Colors.txtWarning}}}");

    public override CTexts Descriptions => CTexts.Make("{헉! 황금 고블린을 잡으면 나오는 코인이다!}");

    public override int SalePrice => 5000;

    public override bool IsSalable => true;

    public ItemGoldGoblinCoin() : base() { }
  }
}