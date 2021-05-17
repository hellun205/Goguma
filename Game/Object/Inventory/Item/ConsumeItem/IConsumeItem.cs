using Goguma.Game.Object.Entity.Player;

namespace Goguma.Game.Object.Inventory.Item.ConsumeItem
{
  interface IConsumeItem : IItem
  {
    int LoseCount { get; set; }
  }
}
