using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Equipment;

namespace Goguma.Game.Object.Inventory.Item.Items
{
  public class Item_GoblinsArmor : EChestplate
  {
    public override ItemList Material => ItemList.GOBLINS_ARMOR;

    public override CTexts Name => CTexts.Make("{고블린의 갑옷}");

    public override CTexts Descriptions => CTexts.Make("{고블린들이 주로 착용하는 갑옷이다.}}");

    public override EquipEffect Effect => new()
    {
      MaxHp = 5,
      DefPer = 0.5
    };

    public override int SalePrice => 5;

    public override bool IsSalable => true;

    public Item_GoblinsArmor() : base() { }
  }
}