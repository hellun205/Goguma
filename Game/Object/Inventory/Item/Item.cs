using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Console;
using System;

namespace Goguma.Game.Object.Inventory.Item
{
  [Serializable]
  abstract class Item : IItem
  {
    public CTexts Name { get; set; }
    public int Count { get; set; }
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
    public Item(in Item item) : this()
    {
      Name = item.Name;
      Count = item.Count;
      SellPrice = item.SellPrice;
      BuyPrice = item.BuyPrice;
      IsAir = item.IsAir;
      Descriptions = item.Descriptions;
    }
    public abstract void DescriptionItem();
    public abstract IItem GetInstance();

  }
}
