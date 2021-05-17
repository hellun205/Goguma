using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Console;
using System;

namespace Goguma.Game.Object.Inventory.Item
{
  [Serializable]
  abstract class Item : IItem
  {
    private int count;
    public CTexts Name { get; set; }
    public int Count
    {
      get => count;
      set => Math.Min(MaxCount, value);
    }
    public abstract int MaxCount { get; }
    public abstract HavingType Type { get; }
    public bool IsAir { get; set; }
    public int SellPrice { get; set; }
    public int BuyPrice { get; set; }
    public CTexts Descriptions { get; set; }
    public Item()
    {
      Count = 1;
    }
    public Item(Item item) : this()
    {
      Name = item.Name;
      Count = item.Count;
    }
    public abstract void UseItem(IPlayer player);
    public abstract void DescriptionItem();
    public abstract IItem GetInstance();
  }
}
