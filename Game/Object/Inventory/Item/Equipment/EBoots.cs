namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  class EBoots : EEquip
  {
    public override WearingType EquipmentType => WearingType.Boots;
    public EBoots() : base() { }
    public EBoots(EBoots item) : base(item) { }

    public override IItem GetInstance()
    {
      return new EBoots(this);
    }
  }
}
