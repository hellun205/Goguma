using System;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  [Serializable]
  public abstract class EHead : EEquip
  {
    public override WearingType EType => WearingType.Head;

    public EHead() : base() { }

    public override string ToString()
    {
      return base.ToString();
    }
  }
}
