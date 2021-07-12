using System.Runtime.CompilerServices;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;

namespace Goguma.Game.Object.Inventory.Item

{
  public interface IItem
  {
    CTexts Name { get; }
    ItemList Material { get; }
    CTexts DisplayName { get; }
    CTexts Descriptions { get; }
    // int Count { get; set; }
    int MaxCount { get; }
    int PurchasePrice { get; }
    int SalePrice { get; }
    bool IsSalable { get; }
    bool IsPurchasable { get; }
    HavingType Type { get; }
    string TypeString { get; }

    void Information(bool isPause = true);
    CTexts Info();
  }
}
