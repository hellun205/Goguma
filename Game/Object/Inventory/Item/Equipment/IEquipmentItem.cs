
using Goguma.Game.Console;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  public interface IEquipmentItem : IItem
  {
    WearingType EquipmentType { get; }
    CTexts EffectInfo(bool isMinus = false);
    CTexts EquipedText();
    CTexts UnEquipedText();
  }
}
