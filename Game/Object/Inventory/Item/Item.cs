using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Console;
using System;

namespace Goguma.Game.Object.Inventory.Item
{
  [Serializable]
  class Item : IItem
  {
    private int count;
    public CTexts Name { get; set; }
    public int Count
    {
      get => count;
      set
      {
        if (count <= MaxCount)
          count = value;
        else
          count = MaxCount;
      }
    }
    public int MaxCount { get; set; }
    public ItemType Type { get; set; }
    public string Lore { get; set; }
    public bool IsAir { get; set; }
    public CTexts Description { get; set; }

    public Item()
    {
      MaxCount = Int32.MaxValue;
      Count = 1;
    }
    static public IItem GetAir()
    {
      IItem resultItem = new Item { IsAir = true };
      return resultItem;
    }

    public void UseItem(IPlayer player) { }

    public void DescriptionItem() { }

    public void DescriptionItemAP(IPlayer player) { }

  }
}
