using System;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  [Serializable]
  public struct EquipEffect
  {
    public double MaxHp { get; set; }
    public double MaxEp { get; set; }
    public double DefPer { get; set; }
  }
}
