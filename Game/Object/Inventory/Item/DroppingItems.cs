using System;
using System.Collections.Generic;
using System.Linq;

namespace Goguma.Game.Object.Inventory.Item
{
  [Serializable]
  class DroppingItem
  {
    public IItem Item { get; set; }
    public int DropChance { get; set; }
    public DroppingItem(IItem item, int dropChance)
    {
      Item = item;
      DropChance = dropChance;
    }
  }
  [Serializable]
  class DroppingItems
  {
    public List<DroppingItem> Items { get; set; }
    public DroppingItems()
    {
      Items = new List<DroppingItem>();
    }
    public DroppingItems(List<DroppingItem> items)
    {
      Items = items;
    }
    public DroppingItem this[int index]
    {
      get => Items[index];
      set => Items[index] = value;
    }
    public List<IItem> Drop()
    {
      var dItems = new List<IItem>();
      var item = from it in Items
                 where it.DropChance >= (int)new Random().Next(1, 101)
                 select it;
      foreach (var it in item)
        dItems.Add(it.Item);
      return dItems;
    }
  }
}