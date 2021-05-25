namespace Goguma.Game.Object.Inventory.Item.Equipment
{
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
