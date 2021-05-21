using System;

namespace Goguma.Game.Object.Inventory.Item.Other
{
  [Serializable]
  class OtherItem : Item
  {
    public override HavingType Type => HavingType.Other;
    public override int MaxCount => 64;
    public OtherItem() : base() { }
    public OtherItem(in OtherItem item) : base(item)
    {

    }

    public override void DescriptionItem()
    {
    }

    public override IItem GetInstance()
    {
      return new OtherItem(this);
    }
  }
}