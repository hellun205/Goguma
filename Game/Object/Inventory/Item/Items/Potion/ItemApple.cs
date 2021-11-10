using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Consume;

namespace Goguma.Game.Object.Inventory.Item.Items
{
  [Serializable]
  public class ItemApple : CPotion
  {
    public override ItemList Material => ItemList.Potion1;

    public override CTexts Name => CTexts.Make("{사과}");

    public static readonly IItem Instance = new ItemApple();

    public override CTexts Descriptions => CTexts.Make("{싱싱한 것 같다. 먹으면 에너지를 조금 회복한다.}}");

    public override PotionEffect Effect => new()
    {
      HealEp = 5
    };

    public override int SalePrice => 10;

    public override bool IsSalable => true;

    public override int PurchasePrice => (int)(SalePrice * 1.25);

    public override bool IsPurchasable => true;
  }
}