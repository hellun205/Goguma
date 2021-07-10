using System;
using Goguma.Game.Object.Inventory.Item;

namespace Goguma.Game.Object.Quest
{
  [Serializable]
  public struct GivingItem
  {
    public ItemList Item { get; set; }
    public int Count { get; set; }

    public GivingItem(ItemList item, int count = 1)
    {
      Item = item;
      Count = count;
    }
  }
}