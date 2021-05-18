using System;
using Goguma.Game.Object.Entity.Player;

namespace Goguma.Game.Object.Inventory.Item
{
  [Serializable]
  class OtherItem : Item
  {
    public override int MaxCount => 64;
    public OtherItem()
    {
      Count = 1;
    }
    public OtherItem(OtherItem item) : this()
    {
      Name = item.Name;
      Count = item.Count;
    }

    public override HavingType Type => HavingType.Other;

    public override void DescriptionItem()
    {
    }

    new public IItem GetInstance()
    {
      return new OtherItem(this);
    }

    public override void UseItem(IPlayer player)
    {
    }
  }
}