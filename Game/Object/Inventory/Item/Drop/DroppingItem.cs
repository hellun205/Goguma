using System;

namespace Goguma.Game.Object.Inventory.Item.Drop
{
  [Serializable]
  public class DroppingItem
  {
    public ItemPair Item { get; set; }
    public int DropChance { get; set; }
    public bool Visible { get; set; }
    public DroppingItem(ItemPair item, int dropChance, bool visible = true)
    {
      Item = item;
      DropChance = dropChance;
      Visible = visible;
    }
  }
}
