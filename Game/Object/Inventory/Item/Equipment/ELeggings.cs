namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  class ELeggings : EEquip
  {
    public override WearingType EquipmentType => WearingType.Leggings;
    public ELeggings() : base() { }
    public ELeggings(ELeggings item) : base(item) { }

    public override IItem GetInstance()
    {
      return new ELeggings(this);
    }
  }
}
