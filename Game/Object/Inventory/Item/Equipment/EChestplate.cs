using System;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  [Serializable]
  public abstract class EChestplate : EEquip
  {
    public override WearingType EType => WearingType.Chestplate;

    public EChestplate() : base() { }

    public override string ToString()
    {
      return base.ToString();
    }
  }
}
