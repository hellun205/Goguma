using System;
using Goguma.Game.Object.Inventory.Item;

namespace Gogu_Remaster.Game.Object.Inventory.Item
{
  [Serializable]
  public class DroppingItem
  {
    public IItem Item { get; set; }
    public int DropChance { get; set; }
    public DroppingItem(IItem item, int dropChance)
    {
      Item = item;
      DropChance = dropChance;
    }
  }
}
