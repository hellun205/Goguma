using Goguma.Game.Object.Entity.Player;

namespace Goguma.Game.Object.Inventory.Item
{
  interface IConsumeItem : IItem
  {
    ItemEffect Effect { get; set; }
    int LoseCount { get; set; }
    new void UseItem(IPlayer player);

    new void DescriptionItem();
    new void DescriptionItemAP(IPlayer player);
  }
}
