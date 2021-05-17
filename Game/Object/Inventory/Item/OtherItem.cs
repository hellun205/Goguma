using System;
using Goguma.Game.Object.Entity.Player;

namespace Goguma.Game.Object.Inventory.Item
{
  [Serializable]
  class OtherItem : Item, IOtherItem
  {
    public override int MaxCount => 64;
    public OtherItem()
    {
      Count = 1;
    }
    public OtherItem(IItem item) : this()
    {
      Name = item.Name;
      Count = item.Count;
    }

    public override HavingType Type => HavingType.Other;

    public override void DescriptionItem()
    {
    }

    public override IItem GetInstance()
    {
      return new OtherItem(this);
    }

    public override void UseItem(IPlayer player)
    {
    }
  }
}