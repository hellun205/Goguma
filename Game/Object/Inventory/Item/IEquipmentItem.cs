using Goguma.Game.Object.Entity.Player;

namespace Goguma.Game.Object.Inventory.Item
{
  public interface IEquipmentItem : IItem
  {
    WearingType EquipmentType { get; set; }
    ItemIncrease Increase { get; set; }
  }
}
