
namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  public interface IEquipmentItem : IItem
  {
    WearingType EquipmentType { get; set; }
    ItemIncrease Increase { get; set; }
  }
}
