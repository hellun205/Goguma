using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Console;
using System;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;
using Colorify;

namespace Goguma.Game.Object.Inventory.Item
{
  [Serializable]
  abstract class Item : IItem
  {
    public CTexts Name { get; set; }
    public int Count { get; set; }
    public abstract int MaxCount { get; }
    public abstract HavingType Type { get; }
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
      Descriptions = item.Descriptions;
    }
    public abstract IItem GetInstance();
    public void Information(bool showCount = true, bool isPause = true)
    {
      PrintCText(Info());
      if (isPause) Pause();
    }

    public override string ToString()
    {
      return Info(false).ToString();
    }

    public abstract CTexts Info(bool showCount = true);

  }
}
