using System;

namespace Goguma.Game.Object.Inventory
{
  [Serializable]
  public struct ItemIncrease
  {
    public double MaxHp { get; set; }
    public double MaxEp { get; set; }
    public double AttDmg { get; set; }
    public double DefPer { get; set; }
  }
}
