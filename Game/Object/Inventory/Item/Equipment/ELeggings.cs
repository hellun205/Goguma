using System;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  [Serializable]
  public abstract class ELeggings : EEquip
  {
    public override WearingType EType => WearingType.LEGGINGS;

    public ELeggings() : base() { }

    public override string ToString()
    {
      return base.ToString();
    }
  }
}
