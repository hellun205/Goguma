using System.Runtime.CompilerServices;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;

namespace Goguma.Game.Object.Inventory.Item

{
  public interface IItem
  {
    CTexts Name { get; set; }
    CTexts Descriptions { get; set; }
    int Count { get; set; }
    int MaxCount { get; }
    int BuyPrice { get; set; }
    int SellPrice { get; set; }
    HavingType Type { get; }

    IItem GetInstance();
    void Information(bool showCount = true, bool isPause = true);
    CTexts Info(bool showCount = true);
  }
}
