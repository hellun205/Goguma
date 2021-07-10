using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;

namespace Goguma.Game.Object.Inventory.Item.Consume
{
  public interface IConsumeItem : IItem
  {
    int LoseCount { get; set; }
    void UseItem(IPlayer player);
    string CTypeString { get; }
    ConsumeItemType CType { get; }
    CTexts EffectInfo();
    CTexts UsedText();
  }
}
