using Goguma.Game.Console;
using System;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game.Object.Inventory.Item
{
  [Serializable]
  abstract class Item : IItem
  {
    public CTexts Name { get; set; }
    public int Count { get; set; }
    public abstract int MaxCount { get; }
    public abstract HavingType Type { get; }
    public string TypeString => InvenInfo.GetTypeString(Type);
    public int SalePrice { get; set; }
    public int PurchasePrice { get; set; }
    public bool IsSalable { get; set; }
    public bool IsPurchasable { get; set; }
    public CTexts Descriptions { get; set; }
    public Item()
    {
      Count = 1;
      SalePrice = 0;
      PurchasePrice = 0;
      IsSalable = false;
      IsPurchasable = false;
    }
    public Item(in Item item) : this()
    {
      Name = item.Name;
      Count = item.Count;
      SalePrice = item.SalePrice;
      PurchasePrice = item.PurchasePrice;
      Descriptions = item.Descriptions;
      IsSalable = item.IsSalable;
      IsPurchasable = item.IsPurchasable;
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
