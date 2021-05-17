using Goguma.Game.Object.Entity.Player;

namespace Goguma.Game.Object.Inventory.Item
{
  interface IConsumeItem : IItem
  {
    ItemEffect Effect { get; set; }
    int LoseCount { get; set; }
  }
}
