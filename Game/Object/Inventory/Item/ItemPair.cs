using System;

namespace Goguma.Game.Object.Inventory.Item
{
  [Serializable]
  public class ItemPair
  {
    public ItemList Item { get; set; }

    public int Count { get; set; }

    public IItem ItemM => Itemss.GetInstance(Item);

    public ItemPair()
    {
      Count = 0;
    }

    public ItemPair(ItemList item, int count = 1)
    {
      Item = item;
      Count = count;
    }
  }
}