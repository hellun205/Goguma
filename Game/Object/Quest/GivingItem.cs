using Goguma.Game.Object.Inventory.Item;

namespace Goguma.Game.Object.Quest
{
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