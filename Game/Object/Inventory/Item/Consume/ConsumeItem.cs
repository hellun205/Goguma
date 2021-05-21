using System;
using Goguma.Game.Object.Entity.Player;

namespace Goguma.Game.Object.Inventory.Item.Consume
{
  [Serializable]
  abstract class ConsumeItem : Item, IConsumeItem
  {
    public override HavingType Type => HavingType.Consume;
    public override int MaxCount => 64;
    public int LoseCount { get; set; }
    public abstract string GetString { get; }

    public ConsumeItem()
    {
      Count = 1;
      LoseCount = 1;
    }

    public ConsumeItem(in ConsumeItem item) : base(item)
    {
      LoseCount = item.LoseCount;
    }

    public abstract void UseItem(IPlayer player);
  }
}