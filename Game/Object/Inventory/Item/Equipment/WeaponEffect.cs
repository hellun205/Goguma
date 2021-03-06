using System;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  [Serializable]
  public struct WeaponEffect
  {
    public double PhysicalDamage { get; set; }

    public double PhysicalPenetration { get; set; }

    public double MagicDamage { get; set; }

    public double MagicPenetration { get; set; }

    public double CritPer { get; set; }

    public double CritDmg { get; set; }

  }
}
