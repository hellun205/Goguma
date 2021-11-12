using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Equipment;

namespace Goguma.Game.Object.Inventory.Item.Items
{
  [Serializable]
  public class ItemGoldGoblinsSword : EWeapon
  {
    public override ItemList Material => ItemList.GOLD_GOBLINS_SWORD;

    public static readonly IItem Instance = new ItemGoldGoblinsSword();

    public override CTexts Name => CTexts.Make($"{{황금 고블린의 검, {Colors.txtWarning}}}");

    public override CTexts Descriptions => CTexts.Make($"{{황금 고블린이 사용하는 검이다.\n}}{{크리티컬 데미지와 확률,{Colors.txtInfo}}}{{이 조금 올라간다.}}");

    public override WeaponEffect Effect => new()
    {
      PhysicalDamage = 9,
      CritDmg = 10,
      CritPer = 10
    };

    public override int SalePrice => 50;

    public override bool IsSalable => true;

    public ItemGoldGoblinsSword() : base() { }
  }
}