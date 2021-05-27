using System;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  [Serializable]
  class EBoots : EEquip
  {
    public override WearingType EType => WearingType.Boots;
    public EBoots() : base() { }
    public EBoots(EBoots item) : base(item) { }

    public override IItem GetInstance()
    {
      return new EBoots(this);
    }

    public override string ToString()
    {
      return base.ToString();
    }
  }
}
