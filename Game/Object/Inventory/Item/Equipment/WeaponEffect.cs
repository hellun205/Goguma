using System;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  [Serializable]
  public struct WeaponEffect
  {
    public double AttDmg { get; set; }
    public double IgnoreDef { get; set; }
    public double CriticalPer { get; set; }
    public double CriticalDmg { get; set; }
  }
}
