using System;

namespace Goguma.Game.Object.Inventory.Item.Drop
{
  [Serializable]
  public class DroppingItem
  {
    public IItem Item { get; set; }
    public int DropChance { get; set; }
    public bool Visible { get; set; }
    public DroppingItem(IItem item, int dropChance, bool visible = true)
    {
      Item = item;
      DropChance = dropChance;
      Visible = visible;
    }
  }
}
