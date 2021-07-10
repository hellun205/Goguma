namespace Goguma.Game.Object.Inventory.Item
{
  public struct ItemPair
  {
    public ItemList Item { get; set; }

    public int Count { get; set; }

    public IItem ItemM => Itemss.GetInstance(Item);

    public ItemPair(ItemList item, int count = 1)
    {
      Item = item;
      Count = count;
    }
  }
}