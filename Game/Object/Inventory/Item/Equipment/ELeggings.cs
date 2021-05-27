using System;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  [Serializable]
  class ELeggings : EEquip
  {
    public override WearingType EquipmentType => WearingType.Leggings;
    public ELeggings() : base() { }
    public ELeggings(ELeggings item) : base(item) { }

    public override IItem GetInstance()
    {
      return new ELeggings(this);
    }

    public override string ToString()
    {
      return base.ToString();
    }
  }
}
