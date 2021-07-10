using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Equipment;

namespace Goguma.Game.Object.Inventory.Item.Items
{
  public class Item_GoblinsSword : EWeapon
  {
    public override ItemList Material => ItemList.GOBLINS_SWORD;

    public override CTexts Name => CTexts.Make("{고블린의 검}");

    public override CTexts Descriptions => CTexts.Make("{고블린들이 주로 사용하는 검이다.}}");

    public override WeaponEffect Effect => new()
    {
      AttDmg = 3
    };

    public override int SalePrice => 7;

    public override bool IsSalable => true;

    public Item_GoblinsSword() : base() { }
  }
}