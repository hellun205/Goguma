
using Goguma.Game.Console;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  public interface IEquipmentItem : IItem
  {
    WearingType EType { get; }
    string ETypeString { get; }
    CTexts EffectInfo(bool isMinus = false);
    CTexts EquipedText();
    CTexts UnEquipedText();
  }
}
