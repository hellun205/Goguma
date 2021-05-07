using Goguma.Game.Object.Enum;

namespace Goguma.Game.Object.Interface
{
  interface IEquipmentItem : IItem
  {
    EquipmentType EquipmentType { get; set; }
    int IncreaseAttDmg { get; set; }
    int IncreaseDefPer { get; set; }
    int IncreaseMaxHp { get; set; }
    int IncreaseMaxEp { get; set; }
  }
}
