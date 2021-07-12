using Colorify;
using Goguma.Game.Console;
using System;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game.Object.Inventory.Item
{
  [Serializable]
  public abstract class Item : IItem
  {
    public abstract CTexts Name { get; }
    public abstract ItemList Material { get; }
    public virtual CTexts DisplayName => CTexts.Make($"{{[ {TypeString} ],{Colors.txtWarning}}}{{ }}").Combine(Name);
    // public int Count { get; set; }
    public abstract HavingType Type { get; }
    public string TypeString => GetTypeString(Type);
    public virtual int SalePrice => 0;
    public virtual int PurchasePrice => SalePrice * 2;
    public virtual bool IsSalable => false;
    public virtual bool IsPurchasable => false;
    public abstract CTexts Descriptions { get; }
    public Item()
    {
      // Count = 1;
    }
    public void Information(bool isPause = true)
    {
      PrintCText(Info());
      if (isPause) Pause();
    }

    public override string ToString()
    {
      return Info().ToString();
    }

    public abstract CTexts Info();

    static public string GetTypeString(HavingType hType)
    {
      switch (hType)
      {
        case HavingType.Equipment:
          return "장비";
        case HavingType.Consume:
          return "소비";
        case HavingType.Other:
          return "기타";
        default:
          return null;
      }
    }
  }
}
