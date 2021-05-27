using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;

namespace Goguma.Game.Object.Inventory.Item.Consume
{
  interface IConsumeItem : IItem
  {
    int LoseCount { get; set; }
    void UseItem(IPlayer player);
    string GetString { get; }
    CTexts EffectInfo();
  }
}
