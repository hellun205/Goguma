using System;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Consume;

namespace Goguma.Game.Object.Inventory.Item.Items
{
  [Serializable]
  public class ItemTestPotion : CPotion
  {
    public override ItemList Material => ItemList.Potion1;

    public override CTexts Name => CTexts.Make("{테스트용 포션}");

    public static readonly IItem Instance = new ItemTestPotion();

    public override CTexts Descriptions => CTexts.Make("{체력을 아주 조금 회복시켜준다.}");

    public override PotionEffect Effect => new()
    {
      HealHp = 10
    };

    public override int SalePrice => 10;

    public override bool IsSalable => true;

    public override int PurchasePrice => (int)(SalePrice * 1.5);

    public override bool IsPurchasable => true;

    public ItemTestPotion() : base() { }
  }
}