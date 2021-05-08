using Goguma.Game.Object.Entity.Player;

namespace Goguma.Game.Object.Inventory.Item
{
  interface IConsumeItem : IItem
  {
    ItemEffect Effect { get; set; }
    new void UseItem(IPlayer toPlayer);

    new void DescriptionItem();
  }
}
