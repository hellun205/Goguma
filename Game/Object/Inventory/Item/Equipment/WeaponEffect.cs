using System;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  [Serializable]
  public struct WeaponEffect
  {
    public double AttDmg { get; set; }
    public double IgnoreDef { get; set; }
    public double CritPer { get; set; }
    public double CritDmg { get; set; }
  }
}
