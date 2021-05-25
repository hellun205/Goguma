using System;
using Colorify;
using Goguma.Game.Console;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Inventory.Item.Equipment
{
  [Serializable]
  abstract class EquipmentItem : Item, IEquipmentItem
  {
    public override HavingType Type => HavingType.Equipment;
    public override int MaxCount => 1;
    public abstract WearingType EquipmentType { get; }
    public EquipmentItem() : base() { }
    public EquipmentItem(in EquipmentItem item) : base(item) { }
  }
}