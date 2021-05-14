using Goguma.Game.Object.Entity.Player;

namespace Goguma.Game.Object.Inventory.Item
{
  public interface IEquipmentItem : IItem
  {
    WearingType EquipmentType { get; set; }
    ItemIncrease Increase { get; set; }

    new void UseItem(IPlayer player);

    new void DescriptionItem();
    new void DescriptionItemAP(IPlayer player);
  }
}
