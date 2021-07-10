using System;
using System.Collections.Generic;
using System.Linq;

namespace Goguma.Game.Object.Inventory.Item.Drop
{
  [Serializable]
  public class DroppingItems
  {
    public List<DroppingItem> Items { get; set; }
    public DroppingItems()
    {
      Items = new();
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
    public List<ItemPair> Drop()
    {
      var dItems = new List<ItemPair>();
      var item = from it in Items
                 where it.DropChance >= (int)new Random().Next(1, 101)
                 select it;
      foreach (var it in item)
        dItems.Add(it.Item);
      return dItems;
    }
  }
}