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
    public HavingType Type { get; set; }
    public bool IsAir { get; set; }
    public CTexts Descriptions { get; set; }

    public Item()
    {
      MaxCount = Int32.MaxValue;
      Count = 1;
    }

    public Item(Item item) : this()
    {
      Name = item.Name;
      Count = item.Count;
    }

    static public IItem GetAir()
    {
      IItem resultItem = new Item { IsAir = true };
      return resultItem;
    }

    public void UseItem(IPlayer player) { }

    public void DescriptionItem() { }

    public void DescriptionItemAP(IPlayer player) { }

    public IItem GetInstance()
    {
      return new Item(this);
    }
  }
}
