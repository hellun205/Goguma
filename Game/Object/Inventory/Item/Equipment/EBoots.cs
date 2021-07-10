using System;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  [Serializable]
  public abstract class EBoots : EEquip
  {
    public override WearingType EType => WearingType.Boots;

    public EBoots() : base() { }

    public override string ToString()
    {
      return base.ToString();
    }
  }
}
