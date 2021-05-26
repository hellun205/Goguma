using System;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  [Serializable]
  class EHead : EEquip
  {
    public override WearingType EquipmentType => WearingType.Head;
    public EHead() : base() { }
    public EHead(EHead item) : base(item) { }

    public override IItem GetInstance()
    {
      return new EHead(this);
    }
  }
}
