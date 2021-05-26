using System;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  [Serializable]
  class EChestplate : EEquip
  {
    public override WearingType EquipmentType => WearingType.Chestplate;
    public EChestplate() : base() { }
    public EChestplate(EChestplate item) : base(item) { }

    public override IItem GetInstance()
    {
      return new EChestplate(this);
    }
  }
}
