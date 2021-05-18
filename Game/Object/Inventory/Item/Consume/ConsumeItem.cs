using System;
using Goguma.Game.Object.Entity.Player;

namespace Goguma.Game.Object.Inventory.Item.Consume
{
  [Serializable]
  abstract class ConsumeItem : Item, IConsumeItem
  {
    public int LoseCount { get; set; }
    public override HavingType Type => HavingType.Consume;
    public override int MaxCount => 64;
    public ConsumeItem()
    {
      Count = 1;
      LoseCount = 1;
    }
    public abstract void UseItem(IPlayer player);
    public abstract string GetString { get; }
  }
}